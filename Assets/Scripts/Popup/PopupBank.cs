using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject popupBank;

    [Header("CashInfo")]
    public TMP_Text cashNum; // 현금 잔고

    [Header("UserInfo")]
    public TMP_Text userName; 
    public TMP_Text balanceNum;  // 통장 잔고

    [Header("ATM")]
    public Button depositBtn;
    public Button withdrawBtn;
    public Button sendBtn;

    [Header("DepositUi")]
    public GameObject depositUi;  // 입금 UI
    public Button depositBtn10000;
    public Button depositBtn30000;
    public Button depositBtn50000;
    public TMP_InputField depositInputField;
    public Button depositInputBtn;
    public Button depositBackBtn;

    [Header("WithdrawUi")]
    public GameObject withdrawUi;  // 출금 UI
    public Button withdrawBtn10000;
    public Button withdrawBtn30000;
    public Button withdrawBtn50000;
    public TMP_InputField withdrawInputField;
    public Button withdrawInputBtn;
    public Button withdrawBackBtn;

    [Header("SendUi")]
    public GameObject sendUi;  // 송금 UI
    public TMP_InputField sendNameInputField;
    public TMP_InputField sendAmountInputField;
    public Button sendInputBtn;
    public Button sendBackBtn;

    [Header("PopupError")]
    public PopupError popupError;

    void Start()
    {
        depositBtn.onClick.AddListener(() => OpenUi(depositUi));
        depositBackBtn.onClick.AddListener(() => CloseUi(depositUi));
        withdrawBtn.onClick.AddListener(() => OpenUi(withdrawUi));
        withdrawBackBtn.onClick.AddListener(() => CloseUi(withdrawUi));
        sendBtn.onClick.AddListener(() => OpenUi(sendUi));
        sendBackBtn.onClick.AddListener(() => CloseUi(sendUi));

        depositBtn10000.onClick.AddListener(() => Deposit(10000));  // 람다식을 사용하여 메서드에 각 금액을 매개변수로 넣어줌
        depositBtn30000.onClick.AddListener(() => Deposit(30000));
        depositBtn50000.onClick.AddListener(() => Deposit(50000));
        depositInputBtn.onClick.AddListener(DepositInputField);

        withdrawBtn10000.onClick.AddListener(() => Withdraw(10000));
        withdrawBtn30000.onClick.AddListener(() => Withdraw(30000));
        withdrawBtn50000.onClick.AddListener(() => Withdraw(50000));
        withdrawInputBtn.onClick.AddListener(WithdrawInputField);

        sendInputBtn.onClick.AddListener(SendInputField);

        Refresh();
    }

    public void Refresh()
    {
        userName.text = $"{GameManager.Instance.userData.userName}";
        cashNum.text = $"{GameManager.Instance.userData.cash:N0}";
        balanceNum.text = $"{GameManager.Instance.userData.balance:N0}";
    }

    public void OpenUi(GameObject ui)
    {
        ui.SetActive(true);
    }

    public void CloseUi(GameObject ui)
    {
        ui.SetActive(false);
    }

    public void Deposit(int amount) // 해당 금액 누르면 입금
    {
        if (GameManager.Instance.userData.cash >= amount)
        {
            GameManager.Instance.userData.balance += amount;
            GameManager.Instance.userData.cash -= amount;
            Refresh();
            GameManager.Instance.SaveUserData(GameManager.Instance.userData);  // 실행 중인 데이터를 저장
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

    public void Withdraw(int amount) // 출금 기능
    {
        if (GameManager.Instance.userData.balance >= amount)
        {
            GameManager.Instance.userData.balance -= amount;
            GameManager.Instance.userData.cash += amount;
            Refresh();
            GameManager.Instance.SaveUserData(GameManager.Instance.userData); // 실행 중인 데이터를 저장
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

    public void SendInputField()
    {
        string sendName = sendNameInputField.text; 
        string sendAmountTxt = sendAmountInputField.text;
        int sendAmount;

        if (string.IsNullOrEmpty(sendName) || string.IsNullOrEmpty(sendAmountTxt))
        {
            popupError.InputEmptyError();
            return;
        }
        else if (!int.TryParse(sendAmountTxt, out sendAmount) || sendAmount <= 0)
        {
            popupError.MinusInputError();
            return;
        }
        else if (GameManager.Instance.userData.balance < sendAmount)
        {
            popupError.NoMoneyError();
            return;
        }

        UserData sendUserData = GameManager.Instance.GetUserData(sendName);

        if (sendUserData == null)
        {
            popupError.UserNotFoundError();
            return;
        }

        GameManager.Instance.userData.balance -= sendAmount; // 송금자의 계좌에서 송금액을 뺌    
        sendUserData.balance += sendAmount;  // 타겟 대상의 계좌에 송금
        GameManager.Instance.SaveUserData(GameManager.Instance.userData);  // 송금자의 데이터 저장
        GameManager.Instance.SaveUserData(sendUserData);  // 타겟 대상의 데이터 저장

        Refresh();
    }

}
