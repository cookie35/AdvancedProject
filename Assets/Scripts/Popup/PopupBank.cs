using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject popupBank;

    [Header("CashInfo")]
    public TMP_Text cashNum; // ���� �ܰ�

    [Header("UserInfo")]
    public TMP_Text userName; 
    public TMP_Text balanceNum;  // ���� �ܰ�

    [Header("ATM")]
    public Button depositBtn;
    public Button withdrawBtn;

    [Header("DepositUi")]
    public GameObject depositUi;  // �Ա� UI
    public Button depositBtn10000;
    public Button depositBtn30000;
    public Button depositBtn50000;
    public TMP_InputField depositInputField;
    public Button depositInputBtn;
    public Button depositBackBtn;

    [Header("WithdrawUi")]
    public GameObject withdrawUi;  // ��� UI
    public Button withdrawBtn10000;
    public Button withdrawBtn30000;
    public Button withdrawBtn50000;
    public TMP_InputField withdrawInputField;
    public Button withdrawInputBtn;
    public Button withdrawBackBtn;

    [Header("PopupError")]
    public PopupError popupError;

    void Start()
    {
        depositBtn.onClick.AddListener(DepositUi); 
        withdrawBtn.onClick.AddListener(WithdrawUi);

        depositBtn10000.onClick.AddListener(() => Deposit(10000));  // ���ٽ��� ����Ͽ� �޼��忡 �� �ݾ��� �Ű������� �־���
        depositBtn30000.onClick.AddListener(() => Deposit(30000));
        depositBtn50000.onClick.AddListener(() => Deposit(50000));
        depositInputBtn.onClick.AddListener(DepositInputField);

        withdrawBtn10000.onClick.AddListener(() => Withdraw(10000));
        withdrawBtn30000.onClick.AddListener(() => Withdraw(30000));
        withdrawBtn50000.onClick.AddListener(() => Withdraw(50000));
        withdrawInputBtn.onClick.AddListener(WithdrawInputField);

        Refresh();
    }

    public void Refresh()
    {
        userName.text = $"{GameManager.Instance.userData.userName}";
        cashNum.text = $"{GameManager.Instance.userData.cash:N0}";
        balanceNum.text = $"{GameManager.Instance.userData.balance:N0}";
    }

    public void DepositUi()
    {
        depositUi.SetActive(true);
    }

    public void WithdrawUi()
    {
        withdrawUi.SetActive(true);
    }

    public void Deposit(int amount) // �ش� �ݾ� ������ �Ա�
    {
        if (GameManager.Instance.userData.cash >= amount)
        {
            GameManager.Instance.userData.balance += amount;
            GameManager.Instance.userData.cash -= amount;
            Refresh();
            GameManager.Instance.SaveUserData(GameManager.Instance.userData);  // ���� ���� �����͸� ����
        }
        else
        {
            popupError.NoMoneyError();
        }
    }

    public void DepositInputField()
    {
        string depositTxt = depositInputField.text;

        if (int.TryParse(depositTxt, out int depositAmount) && depositAmount > 0)
        {
            Deposit(depositAmount);
        }
        else
        {
            popupError.MinusInputError();
        }

    }

    public void Withdraw(int amount) // ��� ���
    {
        if (GameManager.Instance.userData.balance >= amount)
        {
            GameManager.Instance.userData.balance -= amount;
            GameManager.Instance.userData.cash += amount;
            Refresh();
            GameManager.Instance.SaveUserData(GameManager.Instance.userData); // ���� ���� �����͸� ����
        }
        else
        {
            popupError.NoMoneyError();
        }
    }

    public void WithdrawInputField()
    {
        string withdrawTxt = withdrawInputField.text;

        if (int.TryParse(withdrawTxt, out int withdrawAmount) && withdrawAmount > 0)
        {
            Withdraw(withdrawAmount);
        }
    }

}
