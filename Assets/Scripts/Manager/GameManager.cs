using System.IO;
using UnityEngine;

// 게임 전반을 관리하는 중심적인 매니저
// 현금과 잔액을 업데이트

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;  // 실행이 되고 있는 유저 데이터
    private string saveDirectory;  // 데이터 저장 폴더 경로

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 씬에 중복된 GameManager 있으면 삭제
            return;
        }
        DontDestroyOnLoad(gameObject);  // 씬 전환시에도 GameManager는 삭제되지 않음
        saveDirectory = Application.persistentDataPath + "/UserData/";  // 저장 폴더 설정

        if (!Directory.Exists(saveDirectory))   // 예외 처리: 폴더가 없으면 생성
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
        string filePath = Path.Combine(saveDirectory, userData.id + ".json");  // 내 id로 된 파일이 있는지 찾기
        string json = JsonUtility.ToJson(userData);  // Userdata를 json 형식으로 변환
        File.WriteAllText(filePath, json); // filepath에 json파일을 저장
    }

    public UserData LoadUserData(string idSignUp)
    {
        string filePath = Path.Combine(saveDirectory, idSignUp + ".json"); // 아이디로 경로 생성

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);  // json을 userData 형식으로 변환
            return JsonUtility.FromJson<UserData>(json);  // 변환된 userData를 리턴해라. 
        }
        else
        {
            return null;
        }

    }
}
