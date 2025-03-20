using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ������ ����

[System.Serializable]
public class UserData : ScriptableObject
{
    [Header("User Info")]
    public string userName; // ���� ����
    public int cashInt; // ���� �ܾ� (������)
    public int balanceInt; // ���� �ܾ� (������)
}

public class SaveData
{
    public string userNameSave;
    public int cashIntSave;
    public int balanceIntSave;
}

