# Emulator
Emulator Program using C#  
소켓을 활용한 서버, 클라이언트 통신 프로그램으로, 받아온 센서값을 서버로 전송하고 실시간으로 변화를 Database에 기록하는 기기의 에뮬레이터.

## Initial Screen   
![스크린샷 2021-04-22 오후 5 35 29](https://user-images.githubusercontent.com/67997760/115683201-2ae26e80-a391-11eb-8da6-44a5bd023414.png)

## Manual  
- File > Start : Server와 연결 시도. 시간 간격 마다 데이터(기기 정보 및 센서 값) 전송.
- File > End : Server와 연결 해제
- File > Exit Program : 프로그램 종료
    
    
- IP 클릭 : IP주소 설정
- Port 클릭 : Port 번호 설정


## Methodology
1. Socket
> 
2. Thread
> Socket연결을 체크하는 Thread, 값을 수신하면 TextBox에 기록하는 Thread.
3. .ini
> INI(Initialization) 파일 포맷은 설정 파일에 대한 de facto 표준  
> INI 파일은 단순 구조의 텍스트 파일  
>  마이크로소프트 윈도우와 연결되어 있지만 다른 운영 체제에서도 사용가능. "INI 파일"이라는 이름은 ".INI"라는 파일 확장자를 가짐.  
