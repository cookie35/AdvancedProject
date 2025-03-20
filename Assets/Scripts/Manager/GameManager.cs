using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 전반을 관리하는 중심적인 매니저
// 현금과 잔액을 업데이트

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
