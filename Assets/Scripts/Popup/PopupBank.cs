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

    public void Deposit(int amount) // �ش� �ݾ� ������ �Ա�
    {
        if (GameManager.Instance.userData.cashInt >= amount)
        {
            GameManager.Instance.userData.balanceInt += amount;
            GameManager.Instance.userData.cashInt -= amount;
            atmScreen.Refresh();
            GameManager.Instance.SaveUserData(GameManager.Instance.userData);  // ���� ���� �����͸� ����
        }
        else
        {
            popupScreen.SetActive(true);
        }
    }

    public void WithDraw(int amount) // ��� ���
    {
        if (GameManager.Instance.userData.balanceInt >= amount)
        {
            GameManager.Instance.userData.balanceInt -= amount;
            GameManager.Instance.userData.cashInt += amount;
            atmScreen.Refresh();
            GameManager.Instance.SaveUserData(GameManager.Instance.userData); // ���� ���� �����͸� ����
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
