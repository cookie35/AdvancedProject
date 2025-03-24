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
        TMP_Text nowTargetText = null;

        if (ErrorType.ShowPopupError.HasFlag(errorType))
        {
            popupError.SetActive(true);
            nowTargetText = popupErrorTxt;
        }
        else if (ErrorType.ShowPopupSignUp.HasFlag(errorType))
        {
            popupSignUp.errorTxt.gameObject.SetActive(true);
            nowTargetText = popupSignUp.errorTxt;
        }

        switch (errorType)
        {
            case ErrorType.NoMoney:
                nowTargetText.text = "잔액이 부족합니다.";
                break;
            case ErrorType.MinusInput:
                nowTargetText.text = "양수값을 입력해주세요.";
                break;
            case ErrorType.InputEmpty:
                nowTargetText.text = "빈 칸에 값을 입력해주세요";
                break;
            case ErrorType.WrongInputLogin:
                nowTargetText.text = "잘못된 아이디 또는 패스워드입니다.";
                break;
            case ErrorType.UserNotFound:
                nowTargetText.text = "대상이 없습니다.";
                break;
            case ErrorType.SignUpInputEmpty:
                nowTargetText.text = "빈 칸에 값을 입력해주세요";
                break;
            case ErrorType.IdExist:
                nowTargetText.text = "이미 존재하는 아이디입니다.";
                break;
            case ErrorType.PsExist:
                nowTargetText.text = "이미 존재하는 비밀번호입니다.";
                break;
            case ErrorType.PsNotMatch:
                nowTargetText.text = "비밀번호가 일치하지 않습니다.";
                break;
        }
    }
}
