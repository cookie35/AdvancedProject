using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ErrorType
{
    NoMoney = 1 << 0,
    MinusInput = 1 << 1,
    InputEmpty = 1 << 2,
    WrongInputLogin = 1 << 3,
    UserNotFound = 1 << 4,
    SignUpInputEmpty = 1 << 5,
    IdExist = 1 << 6,
    PsExist = 1 << 7,
    PsNotMatch = 1 << 8,

    ShowPopupError = NoMoney | MinusInput | InputEmpty | WrongInputLogin | UserNotFound,
    ShowPopupSignUp = SignUpInputEmpty | IdExist | PsExist | PsNotMatch
}

public class PopupError : MonoBehaviour
{
    [Header("PopupError")]
    public GameObject popupError;
    public TMP_Text popupErrorTxt;
    public Button okBtn;

    [Header("Other Popups")]
    public PopupSignUp popupSignUp;

    private void Start()
    {
        okBtn.onClick.AddListener(ErrorClose);
    }

    private void ErrorClose()
    {
        popupError.SetActive(false);
    }

    public void ShowErrorType(ErrorType errorType)
    {
        TMP_Text nowTargetErrorTxt = null;
        TMP_Text nowTargetSignupErrorTxt = null;

        if (ErrorType.ShowPopupError.HasFlag(errorType))
        {
            popupError.SetActive(true);
            nowTargetErrorTxt = popupErrorTxt;
        }
        else if (ErrorType.ShowPopupSignUp.HasFlag(errorType))
        {
            popupError.SetActive(true);
            nowTargetErrorTxt = popupErrorTxt;
            popupSignUp.errorTxt.gameObject.SetActive(true);
            nowTargetSignupErrorTxt = popupSignUp.errorTxt;
        }

        switch (errorType)
        {
            case ErrorType.NoMoney:
                nowTargetErrorTxt.text = "�ܾ��� �����մϴ�.";
                break;
            case ErrorType.MinusInput:
                nowTargetErrorTxt.text = "������� �Է����ּ���.";
                break;
            case ErrorType.InputEmpty:
                nowTargetErrorTxt.text = "�� ĭ�� ���� �Է����ּ���";
                break;
            case ErrorType.WrongInputLogin:
                nowTargetErrorTxt.text = "�߸��� ���̵� �Ǵ� �н������Դϴ�.";
                break;
            case ErrorType.UserNotFound:
                nowTargetErrorTxt.text = "����� �����ϴ�.";
                break;
            case ErrorType.SignUpInputEmpty:
                nowTargetErrorTxt.text = "������ Ȯ�����ּ���";
                nowTargetSignupErrorTxt.text = "�� ĭ�� ���� �Է����ּ���";
                break;
            case ErrorType.IdExist:
                nowTargetErrorTxt.text = "������ Ȯ�����ּ���";
                nowTargetSignupErrorTxt.text = "�̹� �����ϴ� ���̵��Դϴ�.";
                break;
            case ErrorType.PsExist:
                nowTargetErrorTxt.text = "������ Ȯ�����ּ���";
                nowTargetSignupErrorTxt.text = "�̹� �����ϴ� ��й�ȣ�Դϴ�.";
                break;
            case ErrorType.PsNotMatch:
                nowTargetErrorTxt.text = "������ Ȯ�����ּ���";
                nowTargetSignupErrorTxt.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
                break;
        }
    }
}
