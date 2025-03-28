# ATM System
내일배움캠프 심화과제 개인프로젝트

## 개요
> 이 프로젝트는 Unity를 사용하여 개발된 간단한 ATM 시스템입니다.
> 사용자는 계좌에 로그인하고, 잔액을 확인하며, 입출금 기능을 사용할 수 있습니다.
> 데이터는 파일 시스템을 통해 저장 및 로드됩니다.

## 주요 기능
* 사용자 로그인: 계좌 번호와 PIN을 입력하여 로그인할 수 있습니다.
* 회원 가입: 자신만의 id, userName, password를 만들어 별개의 계좌정보를 저장할 수 있습니다. 
* 잔액 확인: 현재 가지고 있는 현금 / 계좌 잔액을 확인할 수 있습니다.
* 입금 기능: 특정 금액을 계좌에 입금할 수 있습니다.
* 출금 기능: 계좌에서 특정 금액을 출금할 수 있습니다.
* 송금 기능: 특정 금액을 특정 사람의 계좌에 입금할 수 있습니다.
* 데이터 저장 및 로드: 계좌 정보가 파일로 저장되며, 실행 시 데이터를 불러옵니다.

## 사용 방법
1. 프로젝트를 Unity에서 실행합니다.
2. 로그인 화면에서 id와 password를 입력합니다.
   가입된 id가 없을시, sign up 버튼을 눌러 회원가입을 완료합니다.
3. 로그인 후 잔액을 확인할 수 있습니다.
   원하는 금액(10000, 30000, 50000)을 클릭하거나, 직접 입력한 뒤, 확인을 누릅니다.
4. 변경된 잔액이 반영됩니다.
5. 프로그램 종료 후에도 데이터가 저장됩니다.

## 기술 스택
* 엔진: Unity
* 언어: C#
* 아이디 중복 검사, 비밀번호 일치 검사 등의 회원가입 로직
* AddListener 방식을 사용해 버튼 처리
* 람다 표현식: UI 이벤트 처리 최적화
* 비트 플래그(Flags) 사용하여 에러 관리
* 데이터 저장: JSON 파일을 이용한 로컬 저장
