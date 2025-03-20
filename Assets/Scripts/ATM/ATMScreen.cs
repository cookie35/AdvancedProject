using TMPro;
using UnityEngine;

// UI 갱신과 관련된 역할 담당

public class ATMScreen : MonoBehaviour
{
    public GameObject atmWindow;  // 인스펙터 창에서 넣어 줄 atmUi

    [Header("PopupBank")]
    public TextMeshProUGUI balance;  // 통장 잔고 숫자
    public TextMeshProUGUI cash; // 갖고 있는 현금
    public GameObject depositButton;  // 입금 버튼
    public GameObject withdrawButton;  // 출금 버튼
    
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        balance.text = $"{GameManager.Instance.userDataSO.balance:N0}";
        cash.text = $"{GameManager.Instance.userDataSO.cash:N0}";
    }
}
