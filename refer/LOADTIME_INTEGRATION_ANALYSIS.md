# LoadTimeProfiler 가속·접속 안정성 통합 분석

작성일: 2026-07-24  
대상 구현 버전: LoadTimeProfiler 1.1.1

## 0. 1.1.1 최종 구현 결정

실측에서 기존 Connection Stability 설치가 Start To Lobby에 약 6초를 더한 것을 확인한 뒤, 초기 1.1.0 설계보다 좁고 단순한 정책으로 확정했다.

- 설정은 `General.Enabled` 하나만 유지한다. 프로파일링, 안전한 localization cache, config 자동 저장 병합, 최소 연결 보호가 함께 켜지고 꺼진다.
- 연결 제한은 설정값이 아닌 고정 90초 floor다. 원래 90초보다 긴 제한은 줄이지 않는다.
- `ZRpc.SetLongTimeout` postfix, Jötunn `CustomRPC.Timeout`, exact `ServerSync.ConfigSync`, AzuAntiCheat plugin assembly의 `waitForQueue` iterator만 다룬다.
- 전체 assembly 의미 분석, 접속 직전 재검사, fragment TTL 변경, Harmony wrapper rebuild batching은 수행하지 않는다.
- AzuAntiCheat의 해시 대조 및 서버 프로토콜을 복제하지 않는다. 보안 기능을 약화시키지 않고, 알려진 송신 queue의 조기 timeout만 방지한다.
- 접속 계측은 `TransitionToMainScene`에서 시작하고 `Game.SpawnPlayer` 정상 반환에서 성공으로 끝난다.
- 실패는 `Game.Logout` 시각을 후보로 저장한 뒤 `ShowConnectError`의 terminal 상태로 확정한다. 정상적인 lobby 복귀는 cancelled로 분리한다.
- 위 계측은 frame polling 없이 드문 lifecycle event의 timestamp와 상태를 한 번 읽는 방식이므로 의미 있는 병목을 만들지 않는다.

아래의 바이너리 분석 사실은 계속 유효하다. 다만 1.1.0 초안의 선택형 timeout, fragment TTL, Harmony batching 제안과 config 표는 최종 동작이 아니라 검토 기록이며, 충돌할 때는 이 절과 `README.md`의 1.1.1 설명이 우선한다.

## 1. 초기 1.1.0 설계 결론

기존 `StartupAccelerator`, `LocalizationCache`, `TimeoutLimit`의 목적을 그대로 한 DLL에 복사하지 않고, LoadTimeProfiler가 이미 가지고 있는 두 계측 경계에 맞춰 다시 설계했다.

- **Start To Lobby**
  - `Localization.LoadCSV` 결과를 안전하게 재생한다.
  - `Chainloader.Start` 중 BepInEx가 자동으로 발생시키는 config 저장만 파일별 한 번으로 합친다.
  - Harmony wrapper 일괄 재생성은 의미론 위험 때문에 실험 기능으로 제공하고 기본값은 `false`다.
- **Lobby To World**
  - Valheim `ZRpc`와 호환 모드의 연결 타임아웃을 원래 기준보다 짧아지지 않게 조정한다.
  - Jötunn `CustomRPC`, standalone/ILRepack ServerSync, AzuAntiCheat의 검증된 송신 큐 제한시간을 함께 조정한다.
  - 송신 제한시간만 늘릴 때 수신 조각 캐시가 먼저 만료될 위험을 낮추기 위해, 검증된 fragment cache TTL도 함께 늘린다.
- **계측**
  - 가속 cache hit/miss, config 저장 병합, 적용된 queue/TTL target 수, 호환성 실패를 기존 Start To Lobby 및 Lobby To World 보고서에 기록한다.

여기서 “접속 안정성”은 검증된 로컬 제한시간 때문에 정상 진행 중인 접속이 조기에 끊길 위험을 낮춘다는 뜻이다. 상대 서버 오프라인, 버전 불일치, 무한 coroutine, 실제 네트워크 단절까지 성공으로 만들 수는 없다.

## 2. 분석한 바이너리

| 바이너리 | 식별 정보 | SHA-256 | 디컴파일 결과 |
|---|---|---|---|
| Jotunn.dll | `com.jotunn.jotunn` 2.29.2, assembly 2.29.2.0 | `F65751BC15E7AE7466B0F7D3B38C758397741C99A50890DEB19ACF738376BFB1` | `refer/compat/Jotunn` |
| AzuAnticheat.dll | `Azumatt.AzuAntiCheat` 4.3.11, assembly 4.3.11.0 | `BBB2F5204E75BFE03B89D67E0F901E7E3E1768DFF12504155D75981D463F420A` | `refer/compat/AzuAntiCheat` |
| ServerSync.dll | assembly/file 1.0.0.0 | `166956302A294E224474B26F4C7D58409084AD3F48BD0AF1FEB7551F229C8F60` | `refer/compat/ServerSync` |

디컴파일에는 ILSpy 9.1을 사용했다. AzuAntiCheat는 난독화된 일부 iterator를 C#으로 정확히 복원할 수 없어 `refer/compat/AzuAntiCheat/IL/AzuAnticheat.il`의 원본 IL을 함께 보존했다.

## 3. Jötunn 분석

핵심 코드는 `refer/compat/Jotunn/Jotunn/Entities/CustomRPC.cs`다.

### 3.1 실제 Timeout의 의미

- `CustomRPC.Timeout`은 private static mutable `float`이며 기본값은 30초다.
- 이 값은 전체 로그인/handshake/ACK/수신 처리 제한시간이 아니다.
- `peer.m_socket.GetSendQueueSize() > 20000`인 동안 기다리는 **송신 큐 대기 제한시간**이다.
- 대기 시작 시 `Time.time + Timeout`으로 deadline을 한 번 계산한다.
- 제한시간이 지나면 `ErrorConnectFailed`를 보내고 peer를 disconnect한다.
- 큰 package는 fragment마다 새로운 대기 제한시간을 갖는다.

따라서 `CustomRPC.Timeout`만 변경해도 Valheim의 `ZRpc.m_timeout`은 바뀌지 않는다. 두 제한을 별도로 다뤄야 한다.

### 3.2 Lobby To World와의 관계

`SynchronizationManager`는 초기 동기화가 끝날 때까지 `PeerInfo`, routed RPC, ZDO data를 buffer한다. 큰 동기화 package의 송신 큐가 막히면 world 진입 자체가 이 경로에서 지연된다.

Jötunn 초기 동기화 coroutine에는 전체 작업 deadline이나 강제 `finally`가 없다. 그러므로 큐 제한시간 증가는 느리지만 진행 중인 전송에는 도움이 되지만, 끝나지 않는 generator/coroutine을 해결하지는 않는다.

### 3.3 Fragment cache 주의점

수신 fragment cache는 최초 fragment를 받을 때 `DateTimeOffset.Now.AddSeconds(60)`으로 만료를 정한다. queue timeout을 90초로만 늘리면 첫 fragment 뒤 송신 큐가 60초 이상 막혔을 때 앞선 fragment가 먼저 제거될 수 있다.

통합 구현은 Jötunn의 구조를 검증한 뒤 다음 두 값을 같이 적용한다.

- `CustomRPC.Timeout`
- `ReceivePackage`의 검증된 60초 fragment cache lifetime

## 4. ServerSync 분석

핵심 코드는 `refer/compat/ServerSync/ServerSync/ConfigSync.cs`다.

### 4.1 송신 경로

- 원본 data가 10 KB보다 크면 Deflate로 압축한다.
- 압축 결과가 250,000 byte보다 크면 fragment로 나눈다.
- 각 fragment 또는 일반 package 직전에 send queue가 20,000 byte 이하가 될 때까지 기다린다.
- deadline은 `Time.time + 30f`다.
- 만료되면 `ErrorConnectFailed`와 disconnect를 수행한다.
- fragment는 각각 독립된 30초 window를 갖는다.

비-fragment 경로는 timeout으로 disconnect한 뒤에도 outer iterator가 `SendPackage`를 호출할 수 있는 원본 결함이 있다. 이 통합은 타사 state machine의 제어 흐름까지 다시 쓰지 않고 제한시간 상수만 구조 검증 후 바꾸므로, 해당 원본 결함은 별도 upstream 수정 대상이다.

### 4.2 실제 배포 형태

검사한 `newtest` 프로필에서는 다음이 확인됐다.

- 75개 plugin DLL이 `ServerSync.ConfigSync`를 ILRepack으로 내장한다.
- 이 75개 DLL 중 standalone `ServerSync.dll`을 assembly reference로 참조하는 것은 0개다.
- 대부분의 state machine 이름은 `d__55`지만 일부는 `d__56` 또는 다른 형태다.

따라서 LoadTimeProfiler에서 제공된 `ServerSync.dll`을 compile-time reference로 추가하는 방식은 실제 mod pack을 보호하지 못한다. 구현은 각 loaded plugin assembly에서 exact `ServerSync.ConfigSync` type을 찾고, 모든 nested `MoveNext`를 IL 의미 패턴으로 확인한다.

검증 조건은 다음을 포함한다.

- `Time.time + 30f + add`
- `GetSendQueueSize`
- queue threshold 20,000
- `ZNet.Disconnect`

검증된 단일 deadline 상수만 `ConnectionStability.GetTimeoutSeconds()` 호출로 바꾼다. 진단 메시지는 알려진 원문과 일치할 때만 함께 일반화하며, 메시지 문자열 자체는 구조 검증의 필수 조건이 아니다. 타입명 `d__55`, metadata token, MVID는 패치 조건으로 하드코딩하지 않는다.

### 4.3 완료 신호 주의점

- `InitialSyncDone`은 per-mod telemetry에는 쓸 수 있다.
- 하지만 server에 설치되지 않은 선택적 client-only mod는 영원히 `false`일 수 있다.
- `SourceOfTruthChanged`는 첫 fragment를 처리하기 전에도 발생할 수 있다.

따라서 이 두 값을 전체 Lobby To World 완료 gate로 사용하면 안 된다. LoadTimeProfiler는 기존처럼 `PeerInfo`/scene lifecycle과 최종 `Game.SpawnPlayer`를 aggregate 완료 경계로 유지한다.

## 5. AzuAntiCheat 분석

AzuAntiCheat 4.3.11은 ServerSync를 난독화하여 `AzuAnticheat.Internal.RepositoryPublisher` 계열 type으로 포함한다.

### 5.1 검증된 queue iterator

권위 있는 IL 근거는 `refer/compat/AzuAntiCheat/IL/AzuAnticheat.il`의 약 32769–32918행이다.

- deadline: `Time.time + 90f`
- queue threshold: 20,000
- timeout log 후 `ErrorConnectFailed`
- `ZNet.instance.Disconnect(peer)`

이 build의 원래 queue timeout은 이미 90초다. 설정값이 90초 이하면 원래 90초를 유지하고, 90초보다 큰 경우에만 확장하도록 동일 구조 검증을 거친다.

### 5.2 90초 송신/60초 수신 불일치

Azu의 embedded ServerSync 수신 fragment cache는 최초 fragment 기준 고정 60초다. 송신 쪽은 fragment마다 최대 90초 기다릴 수 있으므로 다음 순서가 가능하다.

1. 첫 fragment 수신
2. 다음 fragment 앞에서 송신 큐가 60–90초 정체
3. 다음 fragment 도착
4. 수신 측 cleanup이 기존 fragment를 먼저 삭제
5. package 재조립 미완료

기존 TimeoutLimit 0.2.0은 이 60초 TTL을 변경하지 않는다. 통합 구현은 Azu assembly를 GUID만으로 특정 method에 하드코딩하지 않고, iterator 및 TTL method를 의미 패턴으로 검증한 뒤 timeout과 cache lifetime을 함께 적용한다.

## 6. 안전하게 다시 설계한 Start To Lobby 가속

### 6.1 Localization cache

기존 구현들의 핵심 위험은 다음과 같았다.

- `m_translations` field를 cache dictionary로 교체
- `file.name + language`만 key로 사용하여 서로 다른 TextAsset 충돌 가능
- 다른 mod의 LoadCSV postfix 자체를 patch하여 실행 억제
- 언어 전환과 `Clear()` 뒤 mutable dictionary를 공유

통합 구현은 다음 구조를 사용한다.

```text
ConditionalWeakTable<TextAsset, AssetCache>
  └─ language (Ordinal)
      └─ 실제 Localization.AddWord write sequence
```

- TextAsset 객체 identity를 사용한다.
- 첫 miss에서 `LoadCSV` scope 안의 실제 `AddWord(key, value)` 순서를 기록한다.
- hit에서는 현재 `m_translations` 객체를 유지하고 `Remove` 후 `Add`를 순서대로 재생한다.
- `LoadCSV` entry-guard transpiler를 사용하므로 다른 prefix/postfix는 계속 실행되고 Harmony의 `__runOriginal`도 정상 경로로 유지된다.
- 다른 mod가 `AddWord`, CSV helper(`DoQuoteLineSplit`/`StripCitations`)를 patch했거나 `LoadCSV` body transpiler/ILManipulator를 설치했으면 cache hit를 사용하지 않고 원본으로 fail-open한다.
- prefix와 postfix 사이 dictionary identity가 바뀌면 그 결과를 cache하지 않는다.

### 6.2 Config write coalescing

기존 StartupAccelerator는 새 ConfigFile의 `SaveOnConfigSet`을 false로 바꾸고 나중에 true로 강제 복원했다. 이는 다음을 깨뜨릴 수 있다.

- plugin이 원래 false를 선택한 경우
- startup 뒤 늦게 생성된 ConfigFile
- plugin helper가 현재 `SaveOnConfigSet` 값을 읽고 복원하는 경우
- 예외로 cleanup 경계에 도달하지 못한 경우

통합 구현은 `SaveOnConfigSet`을 전혀 변경하지 않는다.

- Chainloader scope에서 만들어진 ConfigFile만 reference identity로 추적한다.
- `ConfigFile.Save()` 호출 stack이 BepInEx의 `Bind` 또는 `OnSettingChanged` 자동 경로일 때만 저장을 생략한다.
- plugin이 명시적으로 호출한 `Save()`는 즉시 실행한다.
- `Chainloader.Start` finalizer에서 생략된 저장이 있는 파일만 한 번 저장한다.
- finalizer는 정상 반환과 예외 반환 모두 cleanup하며, 주입된 `AfterChainloaderStart`가 idempotent 보조 경계가 된다.
- 다른 Harmony owner가 `ConfigFile.Save`를 patch하면 원본을 건너뛰지 않고 fail-open한다.

자동 저장의 디스크 반영 시점은 `Chainloader.Start` 끝까지 늦어진다. `Bind` 직후 자기 config 파일을 직접 읽거나 file watcher 결과에 의존하는 plugin은 `CoalesceConfigWrites=false`가 필요하다.

### 6.3 Harmony wrapper batching

Harmony 2.9는 patch 하나를 추가할 때마다 target wrapper를 다시 생성한다. 여러 mod가 같은 target을 patch하면 startup 비용이 커질 수 있다.

통합 구현은 `PatchFunctions.UpdateWrapper`를 잠시 모아 target별 한 번만 재생성할 수 있다. 하지만 아래 의미론 위험은 제거할 수 없다.

- 지연 중 `Harmony.Patch()` 반환값이 null
- patch 직후 target을 호출하는 mod의 동작 변경
- transpiler 예외가 원 plugin의 try/catch 밖인 최종 flush에서 발생
- 등록된 PatchInfo와 현재 실행 wrapper가 일시적으로 불일치

따라서 `BatchHarmonyPatches` 기본값은 `false`다. 사용자가 exact mod pack으로 검증한 경우만 opt-in해야 한다.

## 7. Connection stability 구현 원칙

### 7.1 Vanilla ZRpc

`ZRpc.SetLongTimeout(bool)` 원본은 true일 때 90초, false일 때 30초를 static `m_timeout`에 기록한다. IL 상수 두 곳을 직접 바꾸는 대신 다음을 사용한다.

- method와 private static float field 구조를 확인한다.
- 원본 호출 뒤 postfix에서 `max(원래 값, 설정값)`을 field에 적용한다.
- 기능을 끄면 원래 값으로 fail-open한다.

이 방식은 branch 수나 상수 위치 변경에 덜 민감하다.

### 7.2 Jötunn

- `Chainloader.PluginInfos["com.jotunn.jotunn"]`에서 실제 plugin assembly를 얻는다.
- 그 assembly 안의 `Jotunn.Entities.CustomRPC`만 찾는다.
- `Timeout`이 private/static/mutable/float인지 모두 확인한 뒤 설정한다.
- 전역 `AccessTools.TypeByName`으로 이름이 같은 임의 assembly를 선택하지 않는다.

### 7.3 ServerSync와 Azu

- compile-time ServerSync reference를 추가하지 않는다.
- loaded plugin/dependency assembly를 개별적으로 검사한다.
- `ReflectionTypeLoadException.Types`에서 로드 가능한 type을 복구한다.
- queue 및 TTL 의미 패턴이 유일하게 검증된 method만 patch한다.
- 외부 transpiler/ILManipulator가 이미 target을 소유하면 경쟁하지 않고 원본을 유지한다.
- `Harmony.Patch` 반환뿐 아니라 transpiler가 실제 IL 상수를 교체했다는 method별 sentinel까지 확인한다.
- 한 target이 실패해도 나머지 target은 계속 검사한다.
- mismatch는 원본 동작 유지와 진단 기록으로 끝낸다.
- Chainloader 뒤 전체 검사와 접속 시작 시 신규 assembly 재검사를 수행하고, 검사·wrapper 생성 시간을 보고서에 기록한다.

### 7.4 Fragment TTL의 한계와 비용

- 만료 시점은 첫 fragment를 받은 순간 기준으로 고정된다.
- 각 후속 fragment는 별도의 queue timeout window를 가질 수 있으므로 `max(timeout, 90)+30` 하한만으로 임의 개수 fragment의 전체 전송 시간을 수학적으로 보장할 수 없다.
- 기본 600초는 조기 만료 위험을 크게 낮추지만, 불완전 fragment의 dictionary/byte array도 더 오래 유지하므로 공개 서버에서는 메모리 retention이 늘 수 있다.
- 완전한 progress 기반 해법에는 fragment 수신 때마다 만료 갱신, peer별 cache 크기/개수 상한이 필요하며 이는 Jötunn/ServerSync upstream 제어 흐름 변경 범위다.

### 7.5 Legacy 충돌

`com.maxsch.valheim.TimeoutLimit`가 동시에 로드되면 두 구현이 같은 state machine과 Jötunn field의 소유권을 경쟁할 수 있다. 통합 구현은 알려진 legacy plugin을 감지해 충돌 patch를 피하고 경고한다.

최종 배포에서는 다음 legacy DLL을 제거하는 것이 권장된다.

- Smoothbrain StartupAccelerator
- MSchmoecker LocalizationCache
- MSchmoecker TimeoutLimit

## 8. 설정

설정 파일:

```text
BepInEx/config/sighsorry.LoadTimeProfiler.cfg
```

| Section | Key | 기본값 | 설명 |
|---|---|---:|---|
| General | Enabled | true | timing report 활성화. 다른 기능과 독립적 |
| Startup Acceleration | CacheLocalizationCsv | true | 안전한 AddWord sequence cache |
| Startup Acceleration | CoalesceConfigWrites | true | Chainloader 자동 저장 병합 |
| Startup Acceleration | BatchHarmonyPatches | false | 실험적 전역 Harmony rebuild batching |
| Startup Acceleration | HarmonyBatchPassthroughTypes | 빈 문자열 | batching 중 즉시 patch할 full type name |
| Connection Stability | Enabled | true | 연결 안정성 계층 |
| Connection Stability | TimeoutSeconds | 90 | 30–600초. target별 effective 값은 `max(원래 30/90초, 설정값)` |
| Connection Stability | FragmentCacheLifetimeSeconds | 600 | 60–3600초, effective 값은 `max(timeout, 90)+30` 이상. 길수록 불완전 fragment 메모리 유지 시간도 증가 |

client와 dedicated server 양쪽에 설치한다면 같은 timeout 설정을 사용하는 것이 좋다. 런타임 변경은 이미 생성된 deadline/cache에는 소급되지 않으므로 접속 전에 바꾼다.

## 9. 코드 배치

| 파일 | 역할 |
|---|---|
| `Patcher.cs` | 통합 config, 기능 활성 조건, version |
| `RuntimeEntrypoint.cs` | Chainloader 전/후 설치 및 예외 안전 cleanup |
| `StartupAcceleration.cs` | config write coalescing, opt-in Harmony batching |
| `LocalizationAcceleration.cs` | TextAsset/language별 AddWord sequence cache |
| `ConnectionStability.cs` | vanilla/Jötunn/ServerSync/Azu timeout 및 fragment TTL |
| `TimelineProfiler.cs` | Start To Lobby/Lobby To World 진단 section |

## 10. 검증 기준

정적/빌드 검증:

- .NET Framework 4.8 Debug/Release compile
- Thunderstore manifest JSON parse
- 모든 새 source가 old-style csproj의 explicit `Compile` item에 포함
- direct Jötunn/Azu/ServerSync assembly reference가 없음
- legacy owner/GUID 충돌 경로가 fail-open
- 제공된 구조 검증 probe 결과: ServerSync queue 1/TTL 1, Jötunn TTL 1, Azu queue 1/TTL 1
- `newtest` embedded ServerSync 75개 전부 queue target 1개/TTL target 1개, reflection failure 0

실게임 검증:

1. legacy 3개 DLL을 제거한다.
2. 첫 실행과 두 번째 실행의 Start To Lobby 보고서를 비교한다.
3. 언어를 English → Korean → English로 전환하고 누락/중복 key를 확인한다.
4. `BatchHarmonyPatches=false` 기준으로 mod pack 정상 동작을 먼저 확인한다.
5. client/server timeout 설정을 같게 한다.
6. 큰 ServerSync/Jötunn payload로 접속하여 queue deadline 및 fragment TTL target 수를 보고서에서 확인한다.
7. 정상 접속은 `Game.SpawnPlayer`, 실패 접속은 `FejdStartup.ShowConnectError`로 기존 Lobby To World phase가 종료되는지 확인한다.
8. 네트워크를 의도적으로 끊어 timeout을 늘렸어도 무한 대기가 아니라 설정된 제한 뒤 실패하는지 확인한다.

실게임 또는 전용 서버 process를 이 정적 분석 환경에서 실행하지는 않았으므로, 마지막 단계는 실제 mod profile에서 smoke test가 필요하다.
