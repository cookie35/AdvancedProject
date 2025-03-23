using System.IO;
using UnityEngine;

// 게임 전반을 관리하는 중심적인 매니저
// 비밀번호 중복검사, 세이브 및 로드 기능 담당

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // 싱글톤
    public UserData userData;  // 현재 실행이 되고 있는 유저 데이터
    private string saveDirectory;  // 데이터 저장 폴더 경로

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

    public bool IsPasswordExist(string psSignUp) // 비밀번호 중복검사를 위한 메서드
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

    public void SignUpUserData(string idSignUp, string nameSignUp, string psSignUp)  // 회원가입한 데이터 정보 받아오는 메서드
    {
        UserData userData = new UserData();
        userData.id = idSignUp;
        userData.userName = nameSignUp;
        userData.ps = psSignUp;
        SaveUserData(userData);
    }

    public void SaveUserData(UserData userData)  // 유저 데이터 저장하는 메서드
    {
        string filePath = Path.Combine(saveDirectory, userData.id + ".json");  // 내 id로 된 파일이 있는지 찾기
        string json = JsonUtility.ToJson(userData);  // Userdata를 json 형식으로 변환
        File.WriteAllText(filePath, json); // filepath에 json파일을 저장
    }

    public UserData LoadUserData(string idSignUp) // 저장된 데이터 불러오는 메서드
    {
        string filePath = Path.Combine(saveDirectory, idSignUp + ".json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);  // json을 userData 형식으로 변환
            return JsonUtility.FromJson<UserData>(json);  // 변환된 userData를 리턴
        }
        else
        {
            return null;
        }

    }
}
