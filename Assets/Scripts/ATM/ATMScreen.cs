using TMPro;
using UnityEngine;

public class ATMScreen : MonoBehaviour
{
    public GameObject atmWindow;

    [Header("PopupBank")]
    public TextMeshProUGUI balance;  // 통장 잔고 숫자
    public TextMeshProUGUI cash; // 갖고 있는 현금
    public GameObject depositButton;  // 입금 버튼
    public GameObject withdrawButton;  // 출금 버튼

    public int currentBalance = 50000;
    public int currentCash = 100000;
    
    void Start()
    {
        UpdateAtmDisplay();
    }

    // Update is called once per frame
    void UpdateAtmDisplay()
    {
        balance.text = string.Format("{0:N0}", currentBalance); 
        cash.text = string.Format("{0:N0}", currentCash);
    }
}
