using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 팝업이 나타나고 사라지는 기능

public class PopupBank : MonoBehaviour
{
    private ATMScreen atmScreen;
    public GameObject popupScreen;
    public TMP_InputField depositInputField;
    public TMP_InputField withdrawInputField;

    private void Start()
    {
        atmScreen = GetComponent<ATMScreen>();
    }

    public void Deposit(int amount) // 해당 금액 누르면 입금
    {
            if (GameManager.Instance.userData.cashInt >= amount)
            {
                GameManager.Instance.userData.balanceInt += amount;
                GameManager.Instance.userData.cashInt -= amount;
                atmScreen.Refresh();
            }
            else
            {
                popupScreen.SetActive(true);
            }
    }

    public void WithDraw(int amount) // 출금 기능
    {
            if (GameManager.Instance.userData.balanceInt >= amount)
            {
                GameManager.Instance.userData.balanceInt -= amount;
                GameManager.Instance.userData.cashInt += amount;
                atmScreen.Refresh();
            }
            else
            {
                popupScreen.SetActive(true);
            }
    }

    public void DepositInputField()
    {
        string depositTxt = depositInputField.text;

        if (int.TryParse(depositTxt, out int depositAmount) && depositAmount > 0)
        {
            Deposit(depositAmount);
        }

    }

    public void WithDrawInputField()
    {
        string withdrawTxt = withdrawInputField.text;

        if (int.TryParse(withdrawTxt, out int withdrawAmount) && withdrawAmount > 0)
        {
            WithDraw(withdrawAmount);
        }
    }

}
