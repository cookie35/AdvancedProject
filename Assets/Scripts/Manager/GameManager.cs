using System.IO;
using UnityEngine;

// 게임 전반을 관리하는 중심적인 매니저
// 현금과 잔액을 업데이트

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;
    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        savePath = Path.Combine(Application.persistentDataPath, "userData.json");
        Load();
    }

    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.userNameSave = userData.userName;
        saveData.balanceIntSave = userData.balanceInt;
        saveData.cashIntSave = userData.cashInt;
        SaveUserData(saveData);
    }

    public void SaveUserData(SaveData saveData)
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
    }

    public void LoadSaveData(SaveData saveData)
    {
        userData.userName = saveData.userNameSave;
        userData.balanceInt = saveData.balanceIntSave;
        userData.cashInt = saveData.cashIntSave;
    }

    public void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            LoadSaveData(saveData);
        }
        else
        {
            SaveData saveData = new SaveData { userNameSave = "김학영", balanceIntSave = 30000, cashIntSave = 30000 };
            LoadSaveData(saveData);

        }

    }
}
