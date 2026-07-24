# StartupAccelerator / LocalizationCache / TimeoutLimit 정적 분석

분석일: 2026-07-24  
방식: ILSpy `9.1.0.7988` 프로젝트 디컴파일 + Mono.Cecil 메타데이터 검사 + 현재 설치된 BepInEx/Valheim 대상 IL 정적 대조

## 1. 결론 요약

세 DLL은 모두 이름이 보존된 관리형 .NET 어셈블리이며, 네이티브 P/Invoke, 내장 리소스, 별도 네트워크 클라이언트 코드는 확인되지 않았다. 핵심 동작은 BepInEx 설정과 Harmony 패치다.

가장 중요한 판단은 다음과 같다.

1. **StartupAccelerator와 LocalizationCache의 localization 최적화는 기본값으로 동시에 켜지며, 기능이 중복되고 상호 간섭한다.** StartupAccelerator는 `SetupLanguage` 전체를, LocalizationCache는 내부 `LoadCSV`를 캐시한다. LocalizationCache의 `Cache Mods=true`는 다른 모드의 `LoadCSV` postfix 메서드 자체를 이후 실행되지 않게 만든다.
2. **현재 Valheim 구현에서 두 localization 캐시는 런타임 언어 전환에 안전하지 않다.** 둘 다 번역 dictionary의 사본이 아니라 객체 참조를 저장한다. 현재 게임의 `Localization.Clear()`는 그 객체에 `Clear()`를 호출하므로, 캐시된 항목도 함께 비워질 수 있다.
3. **StartupAccelerator의 Harmony 지연 패칭은 총 작업량을 없애기보다 래퍼 재생성 시점과 프로파일 귀속을 이동시킨다.** 개별 플러그인 `Awake`에서 빠진 비용이 `Chainloader.Start` 말미 또는 `FejdStartup.Awake` 말미의 일괄 처리 비용으로 나타난다.
4. **TimeoutLimit는 현재 게임의 vanilla `ZRpc.SetLongTimeout` 패턴과 정적으로 일치한다.** 두 분기 상수 `90s`와 `30s`를 모두 하나의 설정값으로 바꾼다. 기본값은 `90s`이며 값 범위 검증은 없다.
5. 안정성을 우선하면 localization 최적화는 하나만 사용해야 한다. 게임 안에서 언어를 바꾼다면 두 캐시를 모두 끄는 것이 가장 안전하다. TimeoutLimit는 클라이언트와 서버에 동일한 양의 유한값을 사용하는 편이 좋다.

이 문서의 표현은 다음처럼 구분한다.

- **확인**: 대상 DLL IL/디컴파일 코드에서 직접 확인
- **환경 대조**: 현재 설치된 BepInEx 또는 Valheim DLL에서 정적으로 확인
- **추론**: 확인된 코드의 결합으로 예상되는 런타임 영향. 실제 게임 실행 테스트는 하지 않음

## 2. 산출물과 원본 식별

### 디컴파일 산출물

```text
refer/
├─ StartupAccelerator/
│  ├─ StartupAccelerator.csproj
│  ├─ StartupAccelerator/StartupAccelerator.cs
│  └─ Properties/AssemblyInfo.cs
├─ LocalizationCache/
│  ├─ LocalizationCache.csproj
│  ├─ LocalizationCache/Plugin.cs
│  ├─ LocalizationCache/LocalizationPatches.cs
│  ├─ LocalizationCache/DebugTimingPatch.cs
│  └─ Properties/AssemblyInfo.cs
├─ TimeoutLimit/
│  ├─ TimeoutLimit.csproj
│  ├─ TimeoutLimit/Plugin.cs
│  ├─ TimeoutLimit/CodeMatcherExtensions.cs
│  └─ Properties/AssemblyInfo.cs
└─ DLL_ANALYSIS.md
```

### 원본 바이너리

| DLL | 크기 | 어셈블리 버전 | 대상 프레임워크 | MVID | SHA-256 |
|---|---:|---|---|---|---|
| `StartupAccelerator.dll` | 18,432 B | `1.0.0.0` | .NET Framework 4.8 | `234fbd40-1ab6-4047-9a25-064da9047bd4` | `489297E61EFA1698DBC616068D50BA8E70C290F8695EB1B08E15E1759E163790` |
| `LocalizationCache.dll` | 9,728 B | `0.3.0.0` | .NET Framework 4.6.2 | `678dab59-a3bb-4eb7-a620-3af186a2892b` | `16D7BD010AD3559B475D27B20F5225801AD70403167EA8378DAA3395E865E981` |
| `TimeoutLimit.dll` | 16,384 B | `0.2.0.0` | .NET Framework 4.6.2 | `90aabf0b-8f75-497f-8086-968673ad2ffc` | `E4571A5DFCE3B414E2B5EB876D8F3E782CE11D7842782DD39A00B65FB981B809` |

세 원본 모두 IL-only, P/Invoke 0개, module reference 0개, embedded resource 0개다. 인접 PDB는 없었다.

StartupAccelerator의 배포 `manifest.json`은 package version `1.0.3`을 표시하지만 DLL의 어셈블리/파일 버전은 `1.0.0.0`이다. 이 문서에서 코드 버전은 DLL 메타데이터를 기준으로 한다.

### 디컴파일 한계

- 디컴파일 결과는 원본 소스와 의미상 가까운 C# 재구성이며 주석, 별칭, 원래 프로젝트 설정까지 복원하지는 않는다.
- `csproj`는 ILSpy가 생성한 참조용 골격이다. 게임/BepInEx DLL은 복사하지 않았으므로 즉시 재빌드 가능한 독립 소스 패키지는 아니다.
- 핵심 분기와 패치 대상은 원본 IL 및 현재 의존 DLL과 교차 확인했다.

## 3. StartupAccelerator (package 1.0.3 / assembly 1.0.0.0)

주 소스: `StartupAccelerator/StartupAccelerator/StartupAccelerator.cs`

### 3.1 역할과 로딩 시점

이 DLL은 일반 `BaseUnityPlugin`이 아니라 **BepInEx preloader patcher**다.

- `TargetDLLs`는 빈 배열이고 `Patch(AssemblyDefinition)`도 비어 있다.
- 실제 진입점은 `Initialize()`이며, 여기서 BepInEx 내부 `Preloader.PatchEntrypoint`에 transpiler를 설치한다.
- 해당 transpiler가 게임 진입점에 `PreChainloader()` 호출을 추가하고, 그 시점에 나머지 Harmony 패치를 설치한다.

근거: `StartupAccelerator.cs:358-372`

### 3.2 preloader 주입 순서

transpiler는 BepInEx `PatchEntrypoint`의 로컬 번호와 특정 `ILProcessor.InsertBefore` 호출을 찾는다.

- local `6`: `Chainloader.Initialize`용 `MethodReference`
- local `11`: 대상 `ILProcessor`
- local `12`: 진입점의 첫 instruction
- local `7`: `Chainloader.Start`용 `MethodReference`

현재 프로필의 정확한 `BepInEx.Preloader 5.4.22.2` IL과 이 패턴이 일치함을 확인했다.

중요한 구현상 특징은 `foundInitMethod`가 한 번 `true`가 된 후 다시 `false`가 되지 않는다는 점이다. 따라서 현재 BepInEx에서는 helper가 두 번 주입된다.

```text
BepInEx log-list 초기화
→ Chainloader.Initialize
→ PreChainloader #1       실제 패치 설치
→ Chainloader.Start
→ PreChainloader #2       patched guard로 즉시 종료
→ 원래 게임 static constructor
```

두 번째 호출은 `patched` guard 때문에 기능을 중복 적용하지 않는다. BepInEx 구현에 뒤쪽 `InsertBefore`가 더 추가되면 no-op 호출도 더 늘어날 수 있다.

근거: `StartupAccelerator.cs:37-90`

transpiler는 기대 패턴의 발견 횟수를 검증하거나 실패 로그를 남기지 않는다. BepInEx 컴파일 결과가 달라지면 `PreChainloader`가 삽입되지 않거나 잘못된 위치에 여러 번 삽입될 수 있다. 또한 첫 호출은 나머지 `PatchAll`보다 먼저 `patched=true`를 설정하므로 중간 설치가 실패해도 다음 호출에서 재시도하지 않는다.

### 3.3 설정

설정 파일: `BepInEx/config/StartupAccelerator.cfg`

| 섹션/키 | 기본값 | 기능 |
|---|---|---|
| `General / Delay Patching` | `On` | Harmony wrapper 갱신을 두 구간의 끝에서 일괄 처리 |
| `General / Merge Localization Data` | `On` | 언어별 `Localization.SetupLanguage` 결과 캐시 |
| `General / Delay Config Save` | `On` | 시작 중 config 저장을 `FejdStartup.Awake` 직전까지 지연 |
| `General / Passthrough Patched Classes` | 빈 문자열 | comma-separated 타입 FullName을 즉시 패치 대상으로 추가 |

항상 즉시 패치하는 기본 타입은 `System.Reflection.Assembly`, `BepInEx.Preloader.RuntimeFixes.HarmonyInteropFix`, `BepInEx.PluginInfo`, `System.Enum`이다. localization 병합이 켜지면 `Localization`도 추가된다.

근거: `StartupAccelerator.cs:327-354`, `StartupAccelerator.cs:364-380`

### 3.4 Harmony 패치 지연

#### 대상과 단계

| 구간 | 외부 target | 내부에서 임시 패치하는 target | flush 시점 |
|---|---|---|---|
| 1 | `BepInEx.Bootstrap.Chainloader.Start` | `HarmonyLib.PatchFunctions.UpdateWrapper` | `Chainloader.Start` postfix |
| 2 | `FejdStartup.Awake` | 같은 `UpdateWrapper` | `FejdStartup.Awake` postfix |

동작:

1. 구간 시작 prefix가 `UpdateWrapper`에 `SkipUpdates` prefix를 설치한다.
2. passthrough가 아닌 target은 실제 wrapper를 즉시 만들지 않고 `HashSet<MethodBase>`에 기록한다.
3. 구간 끝 postfix가 skip 상태를 끄고, Harmony의 내부 `PatchProcessor.locker` 아래에서 각 메서드의 최종 patch info로 wrapper를 한 번씩 만든다.
4. `PatchManager.AddReplacementOriginal`로 Harmony 내부 상태를 갱신하고 처리 시간과 메서드 수를 로그로 남긴다.

근거: `StartupAccelerator.cs:196-267`

#### 기대 효과

- 여러 모드가 같은 메서드에 차례로 patch를 추가할 때 wrapper를 매번 다시 만들지 않고 마지막에 한 번만 만든다.
- 고유 target 수가 많고 target별 patch 누적 횟수가 많을수록 이득이 커질 수 있다.
- 일괄 처리 비용 자체는 남으므로 총 비용 감소와 함께 **비용 발생 시점 이동**이 생긴다.

#### 위험

- **높음 — Harmony 내부 API 결합:** `PatchFunctions.UpdateWrapper`, `PatchProcessor.locker`, `PatchManager.AddReplacementOriginal`을 reflection으로 직접 사용한다. Harmony 버전 변경에 민감하다.
- **높음 — 즉시 적용 의미 변경:** 한 플러그인이 `Awake` 중 설치한 patch가 같은 startup 구간의 후속 코드에서 즉시 활성화될 것을 기대하면 동작이 달라질 수 있다.
- **높음 — 예외 시 flush 누락:** 구간 경계에는 postfix만 있고 finalizer가 없다. 원본 `Chainloader.Start` 또는 `FejdStartup.Awake`가 예외로 끝나 postfix가 실행되지 않으면 skip 상태와 대기 목록이 남을 수 있다.
- **높음 — 실패 격리 약화:** 대기 target 하나의 transpiler가 throw하면 batch loop 전체가 중단된다. 원래 모드의 `Harmony.Patch()` 호출과 다른 시점에서 오류가 나므로 그 모드가 둔 try/catch도 우회할 수 있다.
- **중간 — Harmony 반환값 변화:** 지연 구간의 `UpdateWrapper`는 `null`을 반환할 수 있다. `Harmony.Patch()`가 돌려준 replacement `MethodInfo`를 즉시 쓰는 모드는 영향을 받을 수 있다.
- **중간 — 타입 FullName 기반 passthrough:** rename, 중첩 타입명 변화, 사용자가 입력한 공백까지 그대로 key에 들어간다. comma split 후 trim을 하지 않는다.
- **낮음/조건부 — 동시성:** 대기 `HashSet` 자체에는 lock이 없지만 일반 `Harmony.Patch/Unpatch`의 `UpdateWrapper` 경로와 flush는 통상 `PatchProcessor.locker` 아래 직렬화된다. Harmony 내부 API를 우회하거나 그 규약 밖에서 직접 호출하는 코드가 있을 때만 경쟁 가능성이 커진다.

### 3.5 localization 병합

#### 캐시

```text
Dictionary<
    language,
    Dictionary<translationKey, translatedText>
>
```

- `Localization.SetupLanguage` prefix/postfix를 priority `0`으로 패치한다.
- miss이면 원본을 실행한다.
- non-English 첫 load는 기존 dictionary를 복제한 뒤 원본을 실행해 English base와 분리하려 한다.
- hit이면 캐시된 dictionary 참조를 `m_translations`에 대입하고 원본 전체를 생략한다.
- 디스크 저장, eviction, 해시, 게임/모드 버전 검사, 명시적 invalidation은 없다.

근거: `StartupAccelerator.cs:95-170`

#### 영어 호환성 보정

캐시된 English를 재사용하면서 실제 선택 언어가 English가 아니면 `Localization.LoadCSV`의 등록된 postfix들을 reflection으로 한 번씩 직접 호출한다.

지원하는 인자 주입은 다음뿐이다.

- `__instance`
- `language`
- `__result=true`
- 이름이 `___`로 시작하는 instance field

`file`, `__originalMethod`, `__state` 등 다른 parameter는 기본 `null`로 남고, ref/out 결과를 되돌려 쓰지 않는다. 임의의 다른 모드 postfix가 더 많은 컨텍스트를 요구하면 오동작하거나 예외를 낼 수 있다. 호출 전체에 try/catch도 없다.

근거: `StartupAccelerator.cs:107-153`

#### 언어 목록 최적화

`Localization.LoadLanguages` 호출 때 singleton이 이미 있으면 원본의 resource 재읽기 대신 `GetLanguages()` 결과를 반환한다.

근거: `StartupAccelerator.cs:174-192`

#### 위험

- **높음 — dictionary 참조 별칭:** 캐시 값은 사본이 아니다. 현재 언어 dictionary가 나중에 `Clear()`되면 캐시도 같이 비워질 수 있다.
- **높음 — 다른 postfix 직접 호출:** Harmony가 보장하는 정상 호출 컨텍스트, 순서, state를 재현하지 않는다.
- **높음/조건부 — 현재 preference API 불일치:** 현재 게임은 선택 언어를 `PlatformPrefs`에서 읽지만 이 DLL의 영어 보정 조건은 `UnityEngine.PlayerPrefs.GetString("language", "English")`을 호출한다. `PlatformPrefs`가 PlayerPrefs fallback을 쓰는 환경에서는 값이 같을 수 있지만, 별도 platform preference provider가 활성화된 환경에서는 실제 선택 언어를 잘못 판단해 보정 postfix를 호출하지 않거나 잘못 호출할 수 있다.
- **중간 — 캐시 stale:** 번역 asset 또는 다른 모드 번역이 같은 프로세스에서 바뀌어도 감지하지 않는다.
- **중간 — lock 부재:** 캐시와 postfix 적용 집합은 startup/main thread 사용을 전제한다.

### 3.6 config 저장 지연

패치:

1. `ConfigFile(string, bool, BepInPlugin)` constructor postfix에서 `SaveOnConfigSet=false`로 바꾸고 인스턴스를 목록에 넣는다.
2. `FejdStartup.Awake` prefix에서 추적한 모든 파일을 한 번씩 저장하고 `SaveOnConfigSet=true`로 복원한다.
3. 모드가 startup 중 `SaveOnConfigSet`을 직접 설정하면 property setter prefix가 먼저 저장하고 추적 목록에서 제거하여 그 모드의 선택을 보존한다.

근거: `StartupAccelerator.cs:272-325`

효과는 각 `Bind`마다 발생하는 config 파일 쓰기를 줄이는 것이다.

위험:

- `ConfigFile(saveOnInit:true)`는 파일이 없을 때 constructor 안에서 먼저 빈 파일을 저장하고, postfix는 constructor 뒤에 실행된다. `FejdStartup.Awake` 전 프로세스가 종료되면 설정 항목이 채워지지 않은 파일만 남을 수 있다.
- 모든 추적 파일을 `FejdStartup.Awake`에서 저장하므로 실제 변경 여부와 무관한 write가 생긴다.
- 저장 예외를 잡지 않는다. 목록을 먼저 새 목록으로 교체한 뒤 순회하므로 한 `Save()`가 실패하면 해당 파일과 뒤쪽 파일은 `SaveOnConfigSet=false`로 남고 기존 재시도 목록에서도 유실된다. 예외도 `FejdStartup.Awake`로 전파된다.
- constructor 및 setter 패치는 `FejdStartup.Awake` 뒤에도 해제되지 않지만 flush는 한 번뿐이다. 이후 새 `ConfigFile`이 만들어지면 `SaveOnConfigSet=false`인 채 목록에 남아 자동 저장이 계속 꺼질 수 있다.
- `FejdStartup.Awake`가 없는 실행 경로나 그 이전의 예외에서는 복구/flush가 누락된다.

StartupAccelerator 자신의 `ConfigFile`은 `PreChainloader` 패치 설치 전에 static 초기화되므로 이 저장 지연 대상이 아니다.

### 3.7 StartupAccelerator 총평

세 DLL 중 성능 잠재력과 호환성 영향이 모두 가장 크다. 현재 프로필의 BepInEx 5.4.22.x 및 Harmony 2.9.0과 참조 버전이 정확히 일치하고 preloader IL 패턴도 맞는다. 그러나 구현이 구체적인 local index와 Harmony 내부 타입에 의존하므로 BepInEx/Harmony 업그레이드 때 가장 먼저 재검증해야 한다.

## 4. LocalizationCache 0.3.0

주 소스:

- `LocalizationCache/LocalizationCache/Plugin.cs`
- `LocalizationCache/LocalizationCache/LocalizationPatches.cs`
- `LocalizationCache/LocalizationCache/DebugTimingPatch.cs`

플러그인 GUID: `com.maxsch.valheim.LocalizationCache`

### 4.1 설정과 설치되는 패치

| 섹션/키 | 기본값 | 시작 시 효과 |
|---|---:|---|
| `1 - General / Enable Cache` | `true` | `LocalizationPatches` 설치 |
| `1 - General / Cache Mods` | `true` | 다른 `LoadCSV` postfix 메서드의 후속 실행 억제 |
| `2 - Debug / Log Timing` | `false` | `SetupLanguage` Stopwatch 패치 설치 |
| `2 - Debug / Log Stacktrace` | `false` | 각 `SetupLanguage` 호출 스택 로그 |

근거: `Plugin.cs:29-45`

`Enable Cache`, `Log Timing`, `Log Stacktrace`는 `Awake`에서 패치 설치 여부를 결정하므로 켜거나 끈 뒤 재시작이 필요하다. 이미 동적으로 억제한 다른 postfix를 세션 중 복원하는 코드는 없다.

### 4.2 실제 캐시

이름과 달리 **디스크 캐시는 전혀 아니다.**

```text
static Dictionary<
    Tuple<TextAsset.name, language>,
    Dictionary<translationKey, translatedText>
>
```

- `Localization.LoadCSV` prefix priority `800`
- miss 또는 null file: 원본 실행
- hit: 캐시 dictionary를 `m_translations`에 대입, `__result=true`, 원본 생략
- postfix priority `0`: 성공 결과의 현재 `m_translations` 참조 저장

근거: `LocalizationPatches.cs:13-49`

캐시에 없는 것:

- `TextAsset` instance identity
- `file.text` 내용/해시/길이/수정 시각
- `Localization` instance
- 게임/모드 버전
- 만료 시각, 용량 제한, clear/eviction

따라서 같은 이름과 언어지만 내용이 다른 asset은 충돌하며, hot reload도 감지하지 않는다. key 비교는 기본 문자열 비교라 대소문자를 구분한다.

### 4.3 다른 모드 localization 억제

`Cache Mods=true`일 때 성공한 `LoadCSV` postfix에서:

1. `LoadCSV`에 등록된 postfix patch 목록을 읽는다.
2. owner가 자기 자신이 아닌 모든 patch를 선택한다.
3. 그 patch의 **`PatchMethod` 자체**에 `SkipLoad` prefix를 단다.
4. `SkipLoad()`가 `false`를 반환하므로 이후 해당 메서드 본문을 생략한다.

근거: `LocalizationPatches.cs:51-70`

이는 `LoadCSV` patch 목록에서 postfix를 제거하는 것보다 영향 범위가 넓다.

- 같은 메서드가 직접 호출되거나 다른 Harmony target의 patch로 재사용되어도 생략될 수 있다.
- 번역 파싱 외의 이벤트, 검증, 상태 갱신도 함께 사라질 수 있다.
- 설명의 “some mods”와 달리 owner 조건을 통과하는 모든 postfix가 대상이다.
- 늦게 등록된 postfix는 이후 성공한 `LoadCSV`가 있어야 발견된다.
- 동적 Harmony patch 실패를 잡지 않는다.

### 4.4 디버그 패치

`Localization.SetupLanguage`:

- prefix priority `800`: `Stopwatch.StartNew()`
- postfix priority `0`: 타이머 정지 후 elapsed milliseconds와 선택적 `StackTrace` 기록

근거: `DebugTimingPatch.cs:8-28`

시간 로그는 유용한 보조 지표지만 stacktrace 생성과 로그 I/O는 프로파일링 결과를 교란할 수 있다.

### 4.5 정확성 위험

- **높음 — 참조 별칭:** 여러 `(file.name, language)` key가 같은 누적 `m_translations` 객체를 가리킬 수 있다. 이후 한 호출의 변경/clear가 여러 캐시 항목을 동시에 바꾼다.
- **높음 — 이름 충돌:** 서로 다른 asset이 같은 이름과 언어를 쓰면 잘못 hit한다.
- **높음 — 다른 postfix의 전역 억제:** 실행 문맥을 구분하지 않고 patch 메서드 자체를 skip한다.
- **중간 — 실패 은폐:** hit이면 실제 asset이나 언어 열의 유효성 검사를 다시 하지 않고 항상 성공을 반환한다.
- **중간 — 예외 전파:** 캐시 경로와 `CacheOtherMods()`에 예외 격리가 없다.
- **중간 — Harmony/게임 내부 결합:** `m_translations` 필드와 `HarmonyLib.Public.Patching` 구조에 직접 의존한다.

### 4.6 현재 Valheim의 언어 전환과 결합

**환경 대조:** 현재 `assembly_guiutils.dll`의 `Localization.SetLanguage`는 다음 순서다.

```text
현재 언어와 다르면
→ PlatformPrefs 갱신
→ Localization.Clear()
→ SetupLanguage(newLanguage)
→ OnLanguageChange
```

`Clear()`는 dictionary를 교체하지 않고 현재 `m_translations.Clear()`를 호출한다. LocalizationCache는 바로 그 객체 참조를 캐시에 넣는다.

**추론:** 한 언어에서 나갈 때 그 언어를 가리키던 캐시도 비워지고, 이미 캐시 key가 있으므로 돌아올 때 빈 dictionary를 hit하여 CSV 원본을 건너뛸 수 있다. 패키지 설명은 `Cache Mods`가 runtime language switching을 깨뜨린다고 밝히지만, 현재 게임 구현에서는 기본 CSV 참조 캐시 자체도 같은 위험을 가진다.

### 4.7 LocalizationCache 총평

반복 CSV 파싱과 반복 모드 postfix를 크게 줄일 수 있지만, 구현은 “결과 snapshot”이 아니라 “mutable global state 참조”를 재사용한다. 고정 언어로 한 번 시작하고 번역을 런타임에 바꾸지 않는 프로필에서 가장 안전하며, 다른 모드 postfix를 억제하는 `Cache Mods=true`가 가장 공격적인 옵션이다.

## 5. TimeoutLimit 0.2.0

주 소스:

- `TimeoutLimit/TimeoutLimit/Plugin.cs`
- `TimeoutLimit/TimeoutLimit/CodeMatcherExtensions.cs`

플러그인 GUID: `com.maxsch.valheim.TimeoutLimit`

### 5.1 설정

| 섹션/키 | 기본값 | 설명 |
|---|---:|---|
| `General / Timeout` | `90.0` | 초 단위 timeout |

근거: `Plugin.cs:39-49`

최솟값/최댓값/유한성 검사가 없다. 음수, `0`, 지나치게 큰 값, config parser가 허용하는 경우 `NaN`/무한대가 그대로 사용될 수 있다.

### 5.2 vanilla `ZRpc.SetLongTimeout`

transpiler는 두 번 나타나는 다음 패턴을 찾는다.

```text
ldc.r4 <constant>
stsfld <field>
```

각 상수 하나를 다음 호출로 교체한다.

```text
Plugin.Timeout
ConfigEntry<float>.Value
```

근거: `Plugin.cs:134-150`

**환경 대조:** 현재 `assembly_valheim.dll`의 메서드는 다음 형태다.

```csharp
if (enable)
    m_timeout = 90f;
else
    m_timeout = 30f;
```

따라서 현 버전에서는 두 패턴이 존재하며 정적으로 일치한다. 패치 후에는 `enable` 값과 무관하게 두 분기가 모두 같은 config 값을 `m_timeout`에 넣는다.

`ZRpc` static constructor의 초기 `m_timeout=30f` 자체는 대상이 아니다. 실제 값은 패치된 `SetLongTimeout`이 호출된 뒤 설정값으로 바뀐다.

### 5.3 Jötunn

`Start()`에서 GUID `com.jotunn.jotunn`을 별도 처리한다. 플러그인 버전이 `2.24.0` 이상이면:

```text
type  = Jotunn.Entities.CustomRPC, Jotunn
field = static Timeout
field value = configured Timeout
```

설정 변경 이벤트에서도 같은 setter를 다시 호출한다.

근거: `Plugin.cs:43-48`, `Plugin.cs:60-65`, `Plugin.cs:125-132`

type/field lookup과 `SetValue`에 예외 처리가 없으므로 Jötunn 내부 이름이 바뀌면 `Start()` 또는 설정 변경 handler가 실패할 수 있다.

### 5.4 embedded ServerSync / ConfigSync 탐색

Jötunn 이외의 각 BepInEx 플러그인 어셈블리를 한 번씩 검사한다.

1. top-level class 이름이 `ConfigSync` 또는 `ServerSync`인 타입을 찾는다.
2. non-public nested type을 두 단계 내려가 이름에 `waitForQueue`가 있는 state machine 후보를 찾는다.
3. 그 타입의 non-public instance `MoveNext`를 transpile한다.
4. `Azumatt.AzuAntiCheat`에는 별도 중첩 구조 탐색과 전용 transpiler가 있다.

근거: `Plugin.cs:53-121`

일반 ServerSync transpiler:

- `Time.time + <float>`의 float 상수를 config timeout getter로 교체
- 정확한 문자열 `Disconnecting {0} after 30 seconds config sending timeout`을 timeout placeholder가 있는 문자열로 교체
- 기존 `string.Format`을 두 argument overload로 교체하여 실제 설정값을 로그에 넣음

근거: `Plugin.cs:177-197`

AzuAntiCheat transpiler:

- 같은 `Time.time + <float>` 패턴 교체
- 찾은 `string.Format` 뒤의 결과를 버리고 `Disconnecting peer after {0} seconds...` 메시지를 다시 생성

근거: `Plugin.cs:200-214`

동적 `MoveNext` patch 자체는 각 메서드별 try/catch가 있다. 그러나 `assembly.GetTypes()`와 type 탐색은 그 try/catch 밖이므로 `ReflectionTypeLoadException` 등은 전체 `Start()`를 중단시킬 수 있다.

### 5.5 timeout 로그 출처 표시

`UnityEngine.Debug.Log(object)` 전체에 prefix를 설치하지만 다음 문자열만 바꾼다.

- `"seconds config sending timeout"`을 포함
- 아직 `"["`로 시작하지 않음

현재 stacktrace에서 TimeoutLimit와 UnityEngine 이외의 첫 assembly를 찾고:

```text
[AssemblyName] 원래 메시지
```

로 다시 로그한 뒤 바깥 원본 로그를 생략한다. 새 메시지는 `[`로 시작하므로 재귀 호출에서 다시 변환되지 않는다.

근거: `Plugin.cs:152-175`

stack frame 탐색 실패는 catch 후 원본 로그를 통과시킨다. 해당 timeout 메시지가 빈번하면 stacktrace 생성 비용이 생기지만 정상적으로는 disconnect 직전의 드문 경로다.

### 5.6 버전/정확성 위험

- **높음 — IL 패턴 결합:** method 이름, state-machine nesting, 문자열 literal, `Time.time + float`, `string.Format` 형태에 의존한다.
- **높음 — 양 끝 불일치:** 한쪽은 더 오래 기다려도 다른 쪽이 먼저 끊을 수 있다. 패키지 README도 client/server 동일 설치 및 설정을 권장한다.
- **중간 — vanilla 두 분기 통합:** 원래 `30s` short 상태까지 설정값으로 바뀌므로 연결 장애 감지가 늦어질 수 있다.
- **중간 — 범위 검증 부재:** 잘못된 값은 즉시 timeout 또는 사실상 무한 대기를 만들 수 있다.
- **중간 — Jötunn reflection 무방비:** 선언된 최소 버전만 검사하고 type/field 존재를 검증하지 않는다.
- **중간 — plugin scan 예외:** 어셈블리 type load 실패 격리가 없다.
- **중간 — mutable IL instruction 공유:** timeout getter 두 instruction을 static 배열 하나로 만들고 모든 transpiler/target에 반복 삽입한다. Harmony 2.9 `CodeMatcher.Insert*`는 이를 clone하지 않으며, `SetLongTimeout` 두 번째 분기의 label도 같은 객체에 붙는다. 현재 ZRpc wrapper 생성은 성공하지만 재적용·다중 ServerSync target·다른 Harmony 버전에서 label/exception-block 상태가 섞일 위험이 있다.
- **낮음 — helper 잔재:** `CodeMatcherExtensions` 중 실제 사용되는 것은 `GetLabels`뿐이며, 나머지는 동작에 영향 없는 개발/디버그 helper로 보인다.

설정을 실행 중 바꾸면 Jötunn static field는 즉시 갱신되고 ZRpc/ServerSync는 다음 계산부터 새 값을 읽는다. 이미 계산한 deadline은 바뀌지 않지만 disconnect 메시지는 로그 시점의 현재 값을 다시 읽으므로, 변경 타이밍에 따라 실제 대기시간과 메시지가 다를 수 있다.

### 5.7 현재 프로필에서 실제 활성 범위

2026-07-24 시점 `startuptest/BepInEx/plugins`의 DLL 3개를 Mono.Cecil로 검사했다.

- `Valheim.DisplayBepInExInfo.dll`
- `LocalizationCache.dll`
- `TimeoutLimit.dll`

`ConfigSync`, `ServerSync`, `Jotunn.Entities.CustomRPC`, AzuAntiCheat 관련 top-level 타입은 없었다. 따라서 현재 프로필 스냅샷에서는 Jötunn/embedded ServerSync/AzuAntiCheat 경로가 아니라 vanilla `ZRpc` 패치와 timeout 로그 prefix가 주 활성 경로다. 모드를 추가하면 이 판단은 달라진다.

## 6. 세 DLL 간 상호작용

| 조합 | 직접 결합 | 실제 영향 |
|---|---|---|
| StartupAccelerator ↔ LocalizationCache | 같은 `Localization` 계열 target | outer `SetupLanguage` cache와 inner `LoadCSV` cache 중복. cache hit 시 inner patch는 실행되지 않음 |
| StartupAccelerator ↔ LocalizationCache `Cache Mods` | foreign postfix 직접 호출/억제 | StartupAccelerator가 호환성을 위해 직접 호출하려는 `LoadCSV` postfix도 `SkipLoad`에 막힐 수 있음 |
| StartupAccelerator ↔ TimeoutLimit | 공통 Harmony wrapper 생성 경로 | TimeoutLimit `Awake`의 `PatchAll` target은 기본 passthrough가 아니므로 Chainloader 끝까지 wrapper 생성 비용이 지연됨 |
| LocalizationCache ↔ TimeoutLimit | 코드/상태 공유 없음 | 하나는 localization 작업량 감소, 다른 하나는 연결 허용 시간을 증가 |

현재 설정 파일은 프로필 `BepInEx/config`에서 발견되지 않았다. 첫 실행 또는 설정 미생성 상태라면 코드 기본값상 StartupAccelerator의 세 최적화와 LocalizationCache의 두 캐시 옵션이 모두 켜지고 Timeout은 `90s`다.

## 7. LoadTimeProfiler와의 상호작용

### 7.1 entrypoint 조합

LoadTimeProfiler는 게임 진입점에서 `Chainloader.Start` 호출을 찾아 바로 앞뒤에 자체 측정 함수를 삽입한다.

근거: 저장소 `Patcher.cs:47-70`

StartupAccelerator의 첫 `PreChainloader`는 `Chainloader.Start` 앞에 먼저 들어가므로, 정적 조합은 다음과 같다.

```text
Chainloader.Initialize
→ StartupAccelerator.PreChainloader #1
→ LoadTimeProfiler.BeforeChainloaderStart
→ Chainloader.Start
→ LoadTimeProfiler.AfterChainloaderStart
→ StartupAccelerator.PreChainloader #2 (no-op)
```

LoadTimeProfiler는 `BeforeChainloaderStart`에서 runtime hook을 설치한다. StartupAccelerator가 `UpdateWrapper` skip을 켜는 시점은 그 뒤인 `Chainloader.Start` prefix이므로 다음 hook은 즉시 활성화된다.

- `GameObject.AddComponent(Type)` plugin construction 측정
- Valheim lifecycle target 측정

근거: `RuntimeEntrypoint.cs:9-23`, `RuntimeHookInstaller.cs:69-125`

### 7.2 측정 귀속 이동

LoadTimeProfiler는 plugin construction과 `Awake`/`OnEnable`을 `GameObject.AddComponent(Type)` 바깥에서 측정하고, 플러그인의 `Start`에는 별도 Harmony patch를 설치한다.

근거: `ChainloaderProfiler.cs:74-106`, `ChainloaderProfiler.cs:160-203`

StartupAccelerator가 활성화되면:

- 각 플러그인 `Awake`에서 요청된 일반 Harmony wrapper 생성 비용은 그 플러그인의 개별 시간에서 빠질 수 있다.
- 해당 비용은 `Chainloader.Start` postfix의 batch flush에 모여 전체 Chainloader 시간과 `scan/load/dependency remainder`로 이동한다.
- `FejdStartup.Awake` 안에서 요청된 patch는 그 lifecycle 말미에 모인다.
- LoadTimeProfiler가 plugin `Start`를 측정하기 위해 추가하는 patch도 Chainloader 구간에서는 지연되지만, Chainloader postfix flush가 실제 Unity `Start`보다 먼저 완료되므로 정상 startup 순서에서는 활성화될 것으로 예상된다.

따라서 StartupAccelerator 사용 전후의 **개별 모드 `Awake` 수치만 비교하면 오해할 수 있고**, 전체 Chainloader 시간, remainder, StartupAccelerator의 `Batch-patched ... in N ms` 로그를 함께 봐야 한다.

### 7.3 DLL별 프로파일 표시

- LocalizationCache는 `Awake`에서 config bind와 Harmony patch를 설치하므로 그 비용이 plugin initialization에 들어간다. 자체 `Start`는 없다.
- TimeoutLimit는 `Awake`의 vanilla patch 설치와 별도로 `Start`에서 모든 플러그인 assembly를 검사하고 동적 patch를 설치한다. LoadTimeProfiler의 plugin `Start` 항목에 잡힌다.
- `Localization.SetupLanguage`/`LoadCSV` callback은 LoadTimeProfiler의 deep attribution target인 `ObjectDB.Awake`와 `ZNetScene.Awake` 자체가 아니다. 선택된 lifecycle 안에서 호출되면 총시간에는 포함될 수 있지만 항상 LocalizationCache 이름으로 세분되지는 않는다.
- LocalizationCache의 `Log Stacktrace`는 반드시 꺼 둔 상태로 성능을 비교하는 편이 좋다.

## 8. 권장 설정과 검증 순서

### 안정성 우선

1. 런타임 언어 전환을 사용하면:
   - StartupAccelerator `Merge Localization Data = Off`
   - LocalizationCache `Enable Cache = false`
2. 언어를 고정하고 localization 가속이 필요하면 둘 중 하나만 켠다.
3. LocalizationCache를 선택한다면 먼저 `Cache Mods = false`로 사용하고, 필요한 성능 이득이 측정될 때만 `true`를 시험한다.
4. TimeoutLimit는 client/server 모두 같은 양의 유한값을 사용한다.

### 정확한 로딩 프로파일 비교

1. 기준 실행:
   - StartupAccelerator `Delay Patching = Off`
   - StartupAccelerator `Merge Localization Data = Off`
   - LocalizationCache `Enable Cache = false`
   - LocalizationCache debug 옵션 모두 `false`
2. 최적화 실행:
   - 기능을 한 번에 하나씩 켜고 새 프로세스로 재측정
3. StartupAccelerator `Delay Patching`을 켠 결과는:
   - 개별 plugin 시간
   - 전체 `Chainloader.Start`
   - `chainloader remainder`
   - `Batch-patched` 로그
   
   를 함께 비교한다.
4. TimeoutLimit는 로딩 성능 최적화가 아니라 실패 허용 시간 변경이므로 성능 baseline과 분리해서 판단한다.

## 9. 현재 환경 정적 대조 정보

### BepInEx 프로필

| 파일 | 버전 | SHA-256 |
|---|---|---|
| `BepInEx.dll` | `5.4.22.0` | `2674D3AECF3097BEE817ABE7E8BBCC42BF583DF51402069D5FCD4FBED55017CE` |
| `BepInEx.Preloader.dll` | `5.4.22.2` | `8CAFF02A8EA13F8DBDD234366181DCCB09FB895A064F4D11172FC1758C337C7D` |
| `0Harmony.dll` | `2.9.0.0` | `1A21CC03424FC82C3DD1346905D16494536B9595AE4162228D99FB7C285C1031` |
| `Mono.Cecil.dll` | `0.10.4.0` | `7AE470288FFF4A402899C254D0A76CEFEF55877F5C54F96E83C797CC5BB6E2F6` |

StartupAccelerator가 참조한 버전과 정확히 일치한다.

### 현재 Valheim 관리 어셈블리

| 파일 | 수정 시각 UTC | SHA-256 | 대조 내용 |
|---|---|---|---|
| `assembly_guiutils.dll` | 2026-05-30 03:28:14 | `70E391B5D1F5DC47BB08850767A3F2D40CA394A49F17045712D9ACBEB15F2C04` | `Localization` 대상 메서드와 `Clear()`의 dictionary mutation |
| `assembly_valheim.dll` | 2026-05-30 03:28:13 | `3B26C8512778F6E0664B5AF2A26F3C30993A00F584C1E76D9123A742B67E2004` | `FejdStartup.Awake`, `ZRpc.SetLongTimeout`과 두 float 상수 |

이 환경 대조는 현재 설치 스냅샷에만 유효하다. 게임, BepInEx, Harmony 또는 관련 모드를 업데이트하면 IL 패턴과 내부 API를 다시 확인해야 한다.
