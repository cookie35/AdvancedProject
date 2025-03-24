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
                nowTargetErrorTxt.text = "잔액이 부족합니다.";
                break;
            case ErrorType.MinusInput:
                nowTargetErrorTxt.text = "양수값을 입력해주세요.";
                break;
            case ErrorType.InputEmpty:
                nowTargetErrorTxt.text = "빈 칸에 값을 입력해주세요";
                break;
            case ErrorType.WrongInputLogin:
                nowTargetErrorTxt.text = "잘못된 아이디 또는 패스워드입니다.";
                break;
            case ErrorType.UserNotFound:
                nowTargetErrorTxt.text = "대상이 없습니다.";
                break;
            case ErrorType.SignUpInputEmpty:
                nowTargetErrorTxt.text = "정보를 확인해주세요";
                nowTargetSignupErrorTxt.text = "빈 칸에 값을 입력해주세요";
                break;
            case ErrorType.IdExist:
                nowTargetErrorTxt.text = "정보를 확인해주세요";
                nowTargetSignupErrorTxt.text = "이미 존재하는 아이디입니다.";
                break;
            case ErrorType.PsExist:
                nowTargetErrorTxt.text = "정보를 확인해주세요";
                nowTargetSignupErrorTxt.text = "이미 존재하는 비밀번호입니다.";
                break;
            case ErrorType.PsNotMatch:
                nowTargetErrorTxt.text = "정보를 확인해주세요";
                nowTargetSignupErrorTxt.text = "비밀번호가 일치하지 않습니다.";
                break;
        }
    }
}
