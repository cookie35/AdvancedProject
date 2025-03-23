using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogin : MonoBehaviour
{
    [Header("PopupLogin")]
    public TMP_InputField idLoginInputField;
    public TMP_InputField psLoginInputField;
    public Button loginBtn;
    public Button signUpBtn;

    [Header("Other Popups")]
    public PopupBank popupBank;
    public PopupSignUp popupSignUp;
    public PopupError popupError;

    private void Start()
    {
        psLoginInputField.contentType = TMP_InputField.ContentType.Password;  // ps 입력시 **로 표시되게 설정

        loginBtn.onClick.AddListener(Login);
        signUpBtn.onClick.AddListener(OpenSignUp);
    }

    private void Login()
    {
        string idLogin = idLoginInputField.text;
        string psLogin = psLoginInputField.text;

        if (string.IsNullOrEmpty(idLogin) || string.IsNullOrEmpty(psLogin))
        {
            popupError.InputEmptyError();
            return;
        }

        UserData loadedData = GameManager.Instance.LoadUserData(idLogin);

        if (loadedData == null)
        {
            popupError.WrongInputLoginError();
            return;
        }

        if (idLogin != loadedData.id || psLogin != loadedData.ps)
        {
            popupError.WrongInputLoginError();
            return;
        }

        GameManager.Instance.userData = loadedData;
        OpenPopupBank();

    }

    private void OpenPopupBank()
    {
        popupBank.gameObject.SetActive(true);
        popupBank.Refresh();
    }

    private void OpenSignUp()
    {
        popupSignUp.gameObject.SetActive(true);
        popupSignUp.errorTxt.gameObject.SetActive(false);
    }
}
