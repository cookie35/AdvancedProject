using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 데이터 저장

[System.Serializable]
public class UserData : ScriptableObject
{
    [Header("User Info")]
    public string userName; // 유저 네임
    public int cashInt; // 현금 잔액 (정수형)
    public int balanceInt; // 통장 잔액 (정수형)
}

public class SaveData
{
    public string userNameSave;
    public int cashIntSave;
    public int balanceIntSave;
}

