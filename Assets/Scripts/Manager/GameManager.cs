using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ �����ϴ� �߽����� �Ŵ���

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userDataSO;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
