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
    public int cash; // ���� 
    public int balance; // ���� �ܾ�
}
