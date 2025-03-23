using System.IO;
using UnityEngine;

// ���� ������ �����ϴ� �߽����� �Ŵ���
// ��й�ȣ �ߺ��˻�, ���̺� �� �ε� ��� ���

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // �̱���
    public UserData userData;  // ���� ������ �ǰ� �ִ� ���� ������
    private string saveDirectory;  // ������ ���� ���� ���

    [Header("Other Popups")]
    public PopupError popupError;

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

    public bool IsPasswordExist(string psSignUp) // ��й�ȣ �ߺ��˻縦 ���� �޼���
    {
        string[] files = Directory.GetFiles(saveDirectory, "*.json");
        foreach (string file in files)
        {
            string json = File.ReadAllText(file);
            UserData userData = JsonUtility.FromJson<UserData>(json);
            if (userData.ps == psSignUp)
            {
                return true;
            }
        }
        return false;
    }

    public void SignUpUserData(string idSignUp, string nameSignUp, string psSignUp)  // ȸ�������� ������ ���� �޾ƿ��� �޼���
    {
        UserData userData = new UserData();
        userData.id = idSignUp;
        userData.userName = nameSignUp;
        userData.ps = psSignUp;
        SaveUserData(userData);
    }

    public void SaveUserData(UserData userData)  // ���� ������ �����ϴ� �޼���
    {
        string filePath = Path.Combine(saveDirectory, userData.id + ".json");  // �� id�� �� ������ �ִ��� ã��
        string json = JsonUtility.ToJson(userData);  // Userdata�� json �������� ��ȯ
        File.WriteAllText(filePath, json); // filepath�� json������ ����
    }

    public UserData LoadUserData(string idSignUp) // ����� ������ �ҷ����� �޼���
    {
        string filePath = Path.Combine(saveDirectory, idSignUp + ".json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);  // json�� userData �������� ��ȯ
            return JsonUtility.FromJson<UserData>(json);  // ��ȯ�� userData�� ����
        }
        else
        {
            return null;
        }

    }
}
