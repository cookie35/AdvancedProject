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
        popupErrorTxt.text = "�ܾ��� �����մϴ�.";
    }

    public void MinusInputError()
    {
        popupError.SetActive(true);
        popupErrorTxt.text = "������� �Է����ּ���.";
    }

    public void InputEmptyError()
    {
        popupError.gameObject.SetActive(true);
        popupErrorTxt.text = "�� ĭ�� ���� �Է����ּ���";
    }

    public void WrongInputLoginError()
    {
        popupError.gameObject.SetActive(true);
        popupErrorTxt.text = "�߸��� ���̵� �Ǵ� �н������Դϴ�.";
    }

    public void UserNotFoundError()
    {
        popupError.gameObject.SetActive(true);
        popupErrorTxt.text = "����� �����ϴ�.";
    }

    public void SignUpInputEmptyError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "�� ĭ�� ���� �Է����ּ���";
    }

    public void IdExistError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "�̹� �����ϴ� ���̵��Դϴ�.";
    }

    public void PsExistError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "�̹� �����ϴ� ��й�ȣ�Դϴ�.";
    }

    public void PsNotMatchError()
    {
        popupSignUp.errorTxt.gameObject.SetActive(true);
        popupSignUp.errorTxt.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
    }

}
