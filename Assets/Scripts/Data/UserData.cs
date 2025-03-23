// 플레이어 데이터 저장

[System.Serializable]
public class UserData
{
    public string id;
    public string ps;
    public string userName; 
    public int cash; // 현금 잔액
    public int balance; // 통장 잔액

    public UserData()  // 초기값 설정
    {
        cash = 50000;
        balance = 50000;
    }

}

