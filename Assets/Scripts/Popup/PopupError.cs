using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void NoMoneyError()
    {
        popupError.SetActive(true);
        popupErrorTxt.text = "잔액이 부족합니다.";
    }

    public void MinusInputError()
    {
        popupError.SetActive(true);
        popupErrorTxt.text = "양수값을 입력해주세요.";
    }

    public void InputEmptyError()
    {
        popupError.gameObject.SetActive(true);
        popupErrorTxt.text = "빈 칸에 값을 입력해주세요";
    }

    public void WrongInputLoginError()
    {
        popupError.gameObject.SetActive(true);
        popupErrorTxt.text = "잘못된 아이디 또는 패스워드입니다.";
    }

    public void UserNotFoundError()
    {
        popupError.gameObject.SetActive(true);
        popupErrorTxt.text = "대상이 없습니다.";
    }

    public void SignUpInputEmptyError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "빈 칸에 값을 입력해주세요";
    }

    public void IdExistError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "이미 존재하는 아이디입니다.";
    }

    public void PsExistError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "이미 존재하는 비밀번호입니다.";
    }

    public void PsNotMatchError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "비밀번호가 일치하지 않습니다.";
    }

}
