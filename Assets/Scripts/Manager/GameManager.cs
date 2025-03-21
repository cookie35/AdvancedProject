using System.IO;
using UnityEngine;

// ���� ������ �����ϴ� �߽����� �Ŵ���
// ���ݰ� �ܾ��� ������Ʈ

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;  // ������ �ǰ� �ִ� ���� ������
    private string saveDirectory;  // ������ ���� ���� ���

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // ���� �ߺ��� GameManager ������ ����
            return;
        }
        DontDestroyOnLoad(gameObject);  // �� ��ȯ�ÿ��� GameManager�� �������� ����
        saveDirectory = Application.persistentDataPath + "/UserData/";  // ���� ���� ����

        if (!Directory.Exists(saveDirectory))   // ���� ó��: ������ ������ ����
        {
            Directory.CreateDirectory(saveDirectory);
        }

    }

    public void SignUpUserData(string idSignUp, string nameSignUp, string psSignUp)
    {
        UserData userData = new UserData();
        userData.id = idSignUp;
        userData.userName = nameSignUp;
        userData.ps = psSignUp;
        SaveUserData(userData);
    }

    public void SaveUserData(UserData userData)
    {
        string filePath = Path.Combine(saveDirectory, userData.id + ".json");  // �� id�� �� ������ �ִ��� ã��
        string json = JsonUtility.ToJson(userData);  // Userdata�� json �������� ��ȯ
        File.WriteAllText(filePath, json); // filepath�� json������ ����
    }

    public UserData LoadUserData(string idSignUp)
    {
        string filePath = Path.Combine(saveDirectory, idSignUp + ".json"); // ���̵�� ��� ����

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);  // json�� userData �������� ��ȯ
            return JsonUtility.FromJson<UserData>(json);  // ��ȯ�� userData�� �����ض�. 
        }
        else
        {
            return null;
        }

    }
}
