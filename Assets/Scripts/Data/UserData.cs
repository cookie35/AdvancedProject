// �÷��̾� ������ ����

[System.Serializable]
public class UserData
{
    public string id;
    public string ps;
    public string userName; 
    public int cash; // ���� �ܾ�
    public int balance; // ���� �ܾ�

    public UserData()  // �ʱⰪ ����
    {
        cash = 50000;
        balance = 50000;
    }

}

