using TMPro;
using UnityEngine;

// UI 갱신과 관련된 역할 담당

public class AtmUi : MonoBehaviour
{
    public GameObject atmWindow;  // 인스펙터 창에서 넣어 줄 atmUi

    [Header("PopupBank")]
    public TextMeshProUGUI cashTxt; // 스크린에 표시되는 현금 잔고 (텍스트)
    public TextMeshProUGUI balanceTxt;  // 스크린에 표시되는 통장 잔고 (텍스트)
    public GameObject depositButton;  // 입금 버튼
    public GameObject withdrawButton;  // 출금 버튼
    
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        balanceTxt.text = $"{GameManager.Instance.userData.balanceInt:N0}";
        cashTxt.text = $"{GameManager.Instance.userData.cashInt:N0}";
    }

}
