using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ �����ϴ� �߽����� �Ŵ���
// ���ݰ� �ܾ��� ������Ʈ

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }

    public void SaveUserData()
    {

    }

    public void LoadUserData()
    {

    }

}
