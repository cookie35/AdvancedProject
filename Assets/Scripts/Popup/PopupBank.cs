using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    private AtmUi atmScreen;
    public GameObject popupScreen;
    public TMP_InputField depositInputField;
    public TMP_InputField withdrawInputField;

    private void Start()
    {
        atmScreen = GetComponent<AtmUi>();
    }

    public void Deposit(int amount) // 해당 금액 누르면 입금
    {
        if (GameManager.Instance.userData.cashInt >= amount)
        {
            GameManager.Instance.userData.balanceInt += amount;
            GameManager.Instance.userData.cashInt -= amount;
            atmScreen.Refresh();
            GameManager.Instance.SaveUserData(GameManager.Instance.userData);  // 실행 중인 데이터를 저장
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
            GameManager.Instance.SaveUserData(GameManager.Instance.userData); // 실행 중인 데이터를 저장
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
