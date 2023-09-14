**벽돌부수기**

**팀명**

I들속에 E하나

Sparta Coding Unity 팀 프로젝트입니다.

추억의 벽돌깨기 게임을 유니티로 구현해보았습니다.

👥 **프로젝트 참여 인원**

조병우,정주찬,최장범,박민호,이두희

⚙️ **개발환경**

C# 

Unity 2022.3.8f1

⏰ **개발일정**

2023.09.08 ~ 2023.09.14

🖼️ **와이어 프레임**
![스크린샷 2023-09-14 105941](https://github.com/Nightshadow0911/spagetti/assets/141592625/1edce6a9-7129-4ce4-8927-bed9f53f275b)
![스크린샷 2023-09-14 105957](https://github.com/Nightshadow0911/spagetti/assets/141592625/c30f76f2-1558-4596-9ac3-0e21c65271d8)
![스크린샷 2023-09-14 110009](https://github.com/Nightshadow0911/spagetti/assets/141592625/351c6b71-f11c-472d-a13d-9a41b7fd8d2e)
<img width="586" alt="스크린샷 2023-09-14 110102" src="https://github.com/Nightshadow0911/spagetti/assets/141592625/8996be9b-dc59-4f58-bbfa-b04682815c34">
<img width="553" alt="스크린샷 2023-09-14 110114" src="https://github.com/Nightshadow0911/spagetti/assets/141592625/b26d8005-7108-4571-864b-fe0a16f17d64">

**기능**

**게임시작 화면**
***
- 스테이지1-5
- 설정 UI
- 크레딧 버튼
- 플레이어 이름 입력 UI

**메인화면**
***
- 벽돌
- 플레이어 패들
- 공
- 목숨 UI
- 현재스코어, 최대스코어
- 설정 UI

**스테이지 1-3**
***
- 클릭 시 공 발사 시작
- 마우스 움직임으로 이동
- 벽, 바 , 벽돌에 닿으면 튕김
- 벽돌 모두 제거시 게임종료
- 벽돌 아이템중 능력치 변화
  - 공추가
  - 생명추가
  - 바 사이즈 증감
  - 공 속도 증감
  - 자석기능

**크레딧창**
***
- 개발팀원명
- 각자 맡은 작업

**맡은 부분**

***주찬***
****
게임 매니저
****
게임 전체적인 관리를 하는 게임 매니저를 구현하였습니다.
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/Managers/GameManager.cs#L1

****
UI
****
UI 매니저를 포함해 인게임 UI를 구현하였습니다.
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/Managers/UIManager.cs#L1
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/UI/LifeBarUI.cs#L1
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/UI/SettingsUI.cs#L1
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/UI/ResultUI.cs#L1
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/UI/ScoreUI.cs#L1

****
페이더 &씬연결
****
장범님이 만드신 SceneFader에 씬 연결 부분을 추가하였습니다.
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/Managers/SceneFader.cs#L1

****
사운드 매니저
****
사운드 매니저를 구현하였습니다.
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Scripts/Managers/SoundManager.cs#L1

****
게임 매니저 에디터, 씬 에디터
****
테스트를 위해 게임 매니저 에디터와 씬 에디터를 구현하였습니다.
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Editor/SceneWindow.cs#L1
https://github.com/Nightshadow0911/spagetti/blob/7568da3b351b7b4c36322b7dcb9ccf411667d806/Assets/Editor/GameHelperEditor.cs#L1


병우:
- 메인화면
- 벽, 패들, 공, 벽돌, 외곽선 프리팹화 및 생성
- 각 물체 간의 충돌 물리 시스템
- 공 속도 및 가속도, 공이 떨어진 후 초기화
- 
    - 벽, 패들, 공, 벽돌 등 프리팹
    - 각 물체 간의 충돌 물리

민호:
- 메인화면
- 인플레이 아이템
  - 공추가
  https://github.com/Nightshadow0911/spagetti/blob/929663ae1b1bff1c6aac2cc0f760616ad2acc9ab/Assets/Scripts/ItemBrick.cs#L58-L64
  - 생명추가
  https://github.com/Nightshadow0911/spagetti/blob/929663ae1b1bff1c6aac2cc0f760616ad2acc9ab/Assets/Scripts/Managers/GameManager.cs#L147-L156
  - 바 사이즈 증감
  https://github.com/Nightshadow0911/spagetti/blob/929663ae1b1bff1c6aac2cc0f760616ad2acc9ab/Assets/Scripts/paddleControl.cs#L33-L55
  - 공 속도 증감
  https://github.com/Nightshadow0911/spagetti/blob/929663ae1b1bff1c6aac2cc0f760616ad2acc9ab/Assets/Scripts/ballControl.cs#L78-L96
  - 자석기능
  https://github.com/Nightshadow0911/spagetti/blob/929663ae1b1bff1c6aac2cc0f760616ad2acc9ab/Assets/Scripts/ballControl.cs#L97C5-L104C6
- 공,패들 움직임
https://github.com/Nightshadow0911/spagetti/blob/929663ae1b1bff1c6aac2cc0f760616ad2acc9ab/Assets/Scripts/ballControl.cs#L25-L53
https://github.com/Nightshadow0911/spagetti/blob/929663ae1b1bff1c6aac2cc0f760616ad2acc9ab/Assets/Scripts/paddleControl.cs#L17-L32

두희:
- 사운드 리소스(배경음악, 효과음)
- 게임 타임 매니저

장범:
- 게임시작화면
- 크레딧화면
- 씬전환 & 페이더효과
- 디자인


**버그 리포트**
***
- Git 씬 충돌 → **씬 따로 만들기**

- VisualStudio 자동완성 버그
    - Edit - External Tools - VisualStudio(version~~)
        - 위의 것이 안될 시 Window - Package Manager - Visual Studio Editor 설치 후 위 동작 수행
- 
- [x]  9/12 오후 5시기준 버그 목록
    - [x]  메인화면 게임 시작후, 세팅에서 BGM조작시 공이 원을 그리며 낙하 또는 스피드가 증가 하는 버그가 있습니다.
    - [x]  공이 튕기다 보면 왼쪽 오른쪽으로만 튕기는 버그 있습니다. 그러다가 왼쪽벽에 충돌이 사라지는 버그까지 연계됩니다.
    - [x]  게임시작후 마우스 왼쪽클릭을 계속하면 위에 명시된 버그가 똑같이 일어납니다.
    - [x]  maincanvas 에서 Name 부분이 GameManager로 표기 되는 버그
- [x]  9/13 오전 10:30 기준 버그
    - [x]  벽돌 다 부수면 게임 오버 안됨
    - [x]  다시하기 눌렀을때 최고점수가 같이 리셋이 되버림
    - [x]  다시하기를 하고나서 게임을 한번더 플레이 한뒤 설정창에서 ‘다시하기’, ‘메인화면’ 기능이 먹통이됨
    - [x]  스테이지2,3 에서 다시하기 누르면 벽돌 라이프 설정이 사라집니다. 그냥 일반 벽돌라이프를 가지게됨.
- [ ]  9/14 오전 10:00 기준 버그
    - [x]  다시하기를 하면 공이 남아있음
    - [x]  ~~공이 추가돼도 모든 공이 생명을 감소시킴~~
    - [x]  다시하기후 공을 발사할때 밑으로 내려갔다가 발사 되는 오류가 간혹 발생   
    - [x]  ~~벽돌 깨질 때 마그내틱 바로 적용~~
    - [x]  ~~공끼리 충돌~~
    - [x]  ~~씬 전환할 때 벽돌이 파괴되면서 OnDestroy를 호출하는데 참조를 잃어버려 에러 발생~~
    - [x]  bgm 조절후 다시하기를 진행하면 bgm은 고정되어있는데 설정UI에서 bgm 조절바는 100으로 되어있음
