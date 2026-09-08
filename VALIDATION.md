# LoadTimeProfiler 1.3.1 검증 기록

검증일: 2026-09-08. 배포 버전을 1.3.1로 올리고 아래 최종 DLL을 다시 검증했습니다. 뒤의 1.3.0 기록은 배포 전 기능 검증 이력이며, 이번 버전에서 반복한 검사와 구분합니다.

## 1.3.1 최종 산출물 검증

- Debug 빌드: `dotnet build LoadTimeProfiler.csproj -c Debug -p:DeployToGame=true` 성공, 경고 0개·오류 0개. 최종 DLL을 로컬 Valheim `BepInEx/patchers`에 자동 복사했고 SHA-256 일치를 확인했습니다: `F90851260295D5B4C5FC42D363E373D191AE52195E302D8E3848768B07F59268`.
- Release DLL 빌드: `dotnet build LoadTimeProfiler.csproj -c Release -p:SkipReleasePackage=true` 성공, 경고 0개·오류 0개. SHA-256: `F4A3F62D4F10F0BFE810B3954534445BE0582972601B10FF9B31D43B706E3517`. 패키징 전 검증에는 이 DLL을 직접 지정했습니다.
- Debug 자동 테스트: 회귀 12/12, 로깅 39/39, 자동 리로드 22/22 통과.
- Release 자동 테스트: 회귀 12/12, 로깅 39/39, 자동 리로드 22/22 통과. 성능 벤치마크는 반복하지 않았습니다.
- Release 실제 Unity 실행: 격리 headless 클라이언트에서 ConfigManager 포함, startup 기능 및 자동 리로드 활성 상태로 201/201 통과, 프로세스 종료 코드 0. 실행에 복사한 DLL과 최종 Release DLL의 해시가 일치합니다.
- 실행 도구의 기존 Gale `worldtest` 기본 경로가 없어 첫 호출은 게임 실행 전에 실패했습니다. 설치된 게임의 `BepInEx/core`를 `-BepInExCorePath`로 명시한 재실행이 위 성공 결과입니다.
- ConfigManager DLL은 아래 이력과 같은 파일을 사용했으며, 이번 릴리스 작업에서 수정하거나 재빌드하지 않았습니다.
- 실제 데디케이트 런타임은 이번 버전에서 반복하지 않았습니다. 아래 161개 결과는 1.3.0 DLL의 이전 검사입니다. 실제 화면 조작, 운영 월드·멀티플레이·동기화 및 성능 A/B도 미검증입니다.

최종 Release 검사 증거(사용자 임시 폴더):

- `LoadTimeProfiler-tests-34d2640803f94b428d546576a8bb785d`
- `LoadTimeProfiler-logging-tests-02ef69a4d96144d791f15b6266abdee1`
- `LoadTimeProfiler-autoreload-tests-7989984146e14247bf13e07e591d59a7`
- `LoadTimeProfiler-unity-7fbb50650b584bcda0ccb0b58f08ad34`

---

# 배포 전 1.3.0 기능 검증 이력

검증일: 2026-09-08. LTP cfg에 알 수 없는 섹션이나 잘못된 값이 있어도 정상 항목의 읽기·리로드·ConfigManager 편집을 허용하도록 변경했습니다. 파일 전체를 거부하던 기존 정책을 항목별 처리로 바꾸는 동작 수정입니다.

## 빌드와 산출물

- Windows, .NET SDK 10.0.200, .NET Framework 4.8, AnyCPU Release 빌드 성공.
- LTP 버전 1.3.0과 단일 patcher DLL, `BepInEx/config/sighsorry.LoadTimeProfiler.cfg`를 유지합니다.
- 최종 LTP DLL SHA-256: `D677DC76312FB9FBAB4EE3D5C25B96E1C9BD3458D125E496D2BA00800C26458F`.
- 검증에 사용한 ConfigManager 1.0.0 DLL SHA-256: `6295204E95436950E333950C97AAD35F9DAE990F48BC7B2A4A42A0886C1EFD6D`. 이번에는 ConfigManager를 수정하거나 재빌드하지 않았습니다.
- 기존 게임·서버 설치나 Gale 프로필의 DLL/cfg는 변경하지 않았습니다. 실행 검사는 임시 실행 파일·BepInEx·cfg·로그·savedir 및 읽기용 에셋 연결을 사용합니다.
- Release 패키지는 DLL, README, VALIDATION, CHANGELOG, manifest, icon을 포함하며 외부 라이브러리를 포함하지 않습니다.

## 이번 설정 정책

알 수 없는 섹션·키는 적용하지 않고 파일에 보존합니다. General의 누락되거나 잘못된 값은 해당 항목의 현재 값을 유지하며, 처음 읽는 파일에서는 기본값을 사용합니다. 존재하지만 잘못된 모드 규칙은 그 GUID의 현재 그룹 또는 처음 읽을 때의 Errors + Warnings를 사용합니다. GUID 규칙을 삭제하면 해당 모드는 Errors + Warnings 기본값으로 돌아갑니다.

중복 키는 마지막 유효 값을 읽으며 UI에서는 마지막 해당 키의 값을 고칩니다. 잘못된 섹션 헤더는 이전 섹션을 끝내므로 그 뒤의 텍스트를 엉뚱한 섹션에 적용하거나 수정하지 않습니다. UI는 누락된 현재 키/섹션을 필요한 경우에만 추가하며 구형 이름을 변환하거나 별칭으로 사용하지 않습니다.

UI 저장은 최신 디스크 내용을 읽고 선택한 값을 수정한 뒤, 유효한 다른 디스크 값까지 하나의 스냅샷으로 게시합니다. 관련 없는 잘못된 값·알 수 없는 텍스트·주석·BOM은 보존합니다. 직접 입력한 값의 타입/범위 오류, 파일 잠금·읽기 실패·잘못된 UTF-8·256KiB 초과·저장 중 외부 변경·종료 이후 접근은 여전히 오류이며 저장되지 않은 값을 게시하지 않습니다.

General 다섯 항목의 실제 동작은 시작 시 고정됩니다. UI와 cfg에서 변경한 General 값은 다음 실행에 적용하고, 활성 LTP 로그 필터의 그룹은 즉시 적용합니다. `ConfigAutoReloadEnabled` 기본 false, ShutUp/QuietLogs 충돌 정책, 선택적 ConfigManager 연동은 유지합니다.

## 자동 테스트

제품을 다시 빌드하는 대신 위 최종 DLL 경로를 명시하여 독립된 Windows .NET Framework x64 프로세스에서 실행했습니다.

| 검사 | 결과 | 범위 |
|---|---:|---|
| `RunRegressionTests.ps1` | 12/12 통과 | config 쓰기 최적화, lifecycle·중첩 계측, LocalizeKey 재생·무효화 |
| `RunLogFilteringTests.ps1` | 39/39 통과 | 항목별 설정 해석·저장·리로드·로그 필터·동시성 |
| `RunConfigAutoReloadTests.ps1` | 22/22 통과 | 실제 ConfigFile·파일 이벤트와 제어 가능한 메인 스레드 전달 큐 |

로깅 suite는 전체 파일 거부를 정답으로 삼던 검사를 항목별 처리 검사로 교체했습니다. 유효/무효 항목 혼합, 누락된 General, 구형 형태 cfg의 UI 편집, 잘못된 선택 값의 복구, BOM·공백·주석·구형/무효 행의 바이트 보존, 중복 키와 재시작 후 읽기, 잘못된 헤더 경계, 같은 진단 반복 방지를 포함합니다. 초기 읽기 실패로 모든 로그를 허용한 뒤 첫 정상 읽기에서 개별 무효 규칙이 기본 그룹으로 돌아가는 경우도 검사했습니다.

기존 16개 로그 그룹 조합, None/미지 비트, 같은 이름의 다른 GUID, 자체·미귀속 로거 통과, 명시적 저장/파일 교체/삭제와 복구, 동시 저장·리로드·스냅샷, 저장 실패의 파일·메모리 보존, 다른 Harmony owner 및 종료 정리도 유지했습니다.

ConfigManager 자체 harness는 이번에 반복하지 않았습니다. 동일 Manager DLL은 앞선 변경에서 외부 설정 13개, 파일 편집 12개, attribute 1개 및 HiddenSettingsParser 검사를 통과했습니다. 이번 LTP 연동은 아래 실제 Unity 실행에서 다시 검사했습니다.

## 실제 Unity/Mono 실행

Valheim 0.221.12, Unity 6000.0.61f1, BepInEx 5.4.23.3, Doorstop 4.4.0 환경입니다.

| 실행 | ConfigManager | 결과 | 종료 코드 |
|---|---|---:|---:|
| 격리 headless 클라이언트, startup 기능 on, ConfigAutoReload on | 포함 | 201/201 통과 | 0 |
| 실제 데디케이트 런타임, startup 기능 off, ConfigAutoReload on | 없음 | 161/161 통과 | 0 |

두 실행 모두 복사된 제품 DLL과 최종 DLL의 해시가 일치하며 실행 프로세스 종료를 확인했습니다. 클라이언트에서는 실제 ConfigManager 등록/조회/저장 콜백으로 미인식 섹션과 잘못된 다른 값이 있어도 로그 체크박스를 저장하고, General이 없는 구형 형태의 문서에 현재 키를 추가하는 경로를 확인했습니다. 유효한 디스크의 다른 항목을 즉시 병합하고, 무효 항목과 주석을 유지하는지 실제 파일과 로그 출력으로 검사했습니다. Start To Lobby 보고서와 General 시작 값 고정도 확인했습니다.

두 런타임에서 LTP 자체 타이머가 잘못된 A 규칙만 유지하면서 유효한 B 규칙을 반영하는지 확인했습니다. 다른 모드 cfg의 실제 파일 저장 이벤트→BepInEx ThreadingHelper→ConfigFile.Reload 경로, 메인 스레드 콜백, SaveOnConfigSet 원복, 연속 저장·같은 파일의 여러 객체·삭제/재생성·서비스 종료도 검사합니다.

데디케이트 검사는 실제 `valheim_server.exe`와 서버 어셈블리를 사용하지만, 테스트 전용 Harmony 가드가 FejdStartup.Awake와 ZNet.Awake의 플랫폼 로그인·월드·네트워크 초기화를 막습니다. 접속자나 ConfigManager 없이 서버 런타임의 파일 리로드를 검증하는 검사이며, 운영 서버 월드나 실제 접속·ServerSync 전송을 검증한 것은 아닙니다. 클라이언트도 서버에 접속하거나 월드를 만들지 않았습니다.

그래픽 없는 실행이므로 ConfigManager의 실제 화면 클릭·회색 표시·입력 포커스·UI 배율은 미검증입니다. 그래픽/플랫폼 오류가 기록될 수 있으며 게임 전체의 무오류 동작을 보장하지 않습니다. 원본 ShutUp/QuietLogs 실행은 이번 범위에 포함하지 않았습니다. 직전 LTP 빌드 `D1ECF48270B191964B9815386435CF0072604EFCE029D911F9AD9408C8AFB44D`에서는 ShutUp 이름의 무동작 테스트 어셈블리로 충돌/읽기 전용 경로 96개를 검사했으며, 이를 이번 최종 DLL 재검증으로 간주하지 않습니다.

실행 증거는 임시 폴더에 보관합니다:

- `LoadTimeProfiler-tests-efa7f9925bef42bd851fd51bcc680729`
- `LoadTimeProfiler-logging-tests-ae099735ee4f4e248965aa3ef15bd34f`
- `LoadTimeProfiler-autoreload-tests-0ae2a1b5bb534b0a969b69e18b6dcd2a`
- `LoadTimeProfiler-unity-116675db4a7f46468946a1508fef441c`
- `LoadTimeProfiler-unity-50580652e9264c0d9e82d0e426f7d980`

## 비용과 한계

변경은 파일이 바뀌었거나 UI에서 저장할 때의 해석·편집 경로에 한정됩니다. 매 프레임 검색이나 UI 재생성, 매 로그 호출 스택 분석을 추가하지 않았습니다. 기존 LTP 500ms 타이머와 불변 스냅샷 조회는 유지합니다. 파일 재읽기·해석·해시·외부 모드 콜백 비용은 남으며 CPU·GC·로딩 시간·FPS/tick A/B는 측정하지 않았습니다.

유효한 항목별 결과를 한 번 게시해도 외부 편집기가 저장을 잠시 멈춘 상태를 완성된 편집과 완전히 구분할 수는 없습니다. 최종 디스크 확인 뒤 다른 프로세스가 rename/replace하는 경쟁도 완전한 CAS로 막지 못합니다. 이러한 한계는 파일 이벤트 병합과 원자적 교체만으로 해결되지 않습니다.

다른 모드의 범용 cfg 리로드는 설정값 갱신을 실행할 뿐, 초기 캐시·이미 설치한 패치·생성된 객체를 재구성하지 않습니다. 외부 모드의 자체 watcher/명시적 Save/무거운 콜백과 ServerSync/Jotunn 동기화 정책은 그 모드에 남습니다. 이번 변경은 네트워크 소유권·권한·중복 처리·아이템 생성/삭제 로직을 수정하지 않습니다.

## 아직 필요한 검증

1. 화면에서 실제 체크박스·숫자·Edit·Reset을 조작하고 서로 다른 UI 배율/모드 조합 확인.
2. 운영 월드의 데디케이트 서버에서 수정·저장한 뒤 접속/재접속과 ServerSync/Jotunn 동기화 등록·미등록 항목 확인.
3. 원본 ShutUp/QuietLogs 및 자체 watcher·캐시·명시적 Save를 사용하는 실제 모드팩 조합.
4. Linux 파일시스템, 장시간 실행, 대량 cfg/저장 부하, frame/tick/GC 비용.
5. 외부 설정 변경 콜백의 실제 월드·아이템 동작과 소실/복제 방지 확인.
