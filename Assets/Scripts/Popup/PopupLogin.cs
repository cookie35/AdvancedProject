using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField idLoginInputField;
    public TMP_InputField psLoginInputField;
    public TMP_InputField idSignUpInputField;
    public TMP_InputField nameSignUpInputField;
    public TMP_InputField psSignUpInputField;
    public TMP_InputField psConfirmSignUpInputField;

    public GameObject loginButton;
    public GameObject signUpButton;
    public GameObject signUpCancelButton;
    public GameObject signUpConfirmButton;
    public GameObject errorCloseButton;

    public TextMeshProUGUI errorText;
    public TextMeshProUGUI confirmText;

    public GameObject atmUi;
    public GameObject signUpPanel;
    public GameObject errorPanel;

    public UserData userData;

    void Start()
    {
        psLoginInputField.contentType = TMP_InputField.ContentType.Password;
        psSignUpInputField.contentType = TMP_InputField.ContentType.Password;
        psConfirmSignUpInputField.contentType = TMP_InputField.ContentType.Password;

        loginButton.GetComponent<Button>().onClick.AddListener(Login);
        signUpButton.GetComponent<Button>().onClick.AddListener(OpenSignUp);
        signUpCancelButton.GetComponent<Button>().onClick.AddListener(SignUpCancel);
        signUpConfirmButton.GetComponent<Button>().onClick.AddListener(SignUpConfirm);
        errorCloseButton.GetComponent<Button>().onClick.AddListener(ErrorClose);
        
        errorPanel.gameObject.SetActive(false);
    }

    private void Login()  
    {
        string idLogin = idLoginInputField.text;
        string psLogin = psLoginInputField.text;

        if (string.IsNullOrEmpty(idLogin) || string.IsNullOrEmpty(psLogin))
        {
            errorPanel.gameObject.SetActive(true);
            errorText.text = "아이디와 비밀번호를 입력해주세요";
        }

        UserData loadedData = GameManager.Instance.LoadUserData(idLogin);

        if (loadedData == null)
        {
            errorPanel.gameObject.SetActive(true);
            errorText.text = "아이디 또는 비밀번호가 잘못되었습니다.";
            return;
        }

        if (psLogin == loadedData.ps)
        {
            GameManager.Instance.userData = loadedData;
            OpenAtmUi();
        }
        else
        {
            errorPanel.gameObject.SetActive(true);
            errorText.text = "아이디 또는 비밀번호가 잘못되었습니다.";
            return;
        }

    }

    private void OpenAtmUi()
    {
        atmUi.gameObject.SetActive(true);
    }

    private void OpenSignUp()
    {
        signUpPanel.gameObject.SetActive(true);
    }

    private void SignUpCancel()
    {
        signUpPanel.gameObject.SetActive(false);
    }

    private void SignUpConfirm()
    {
        string idSignUp = idSignUpInputField.text;
        string nameSignUp = nameSignUpInputField.text;
        string psSignUp = psSignUpInputField.text;
        string psConfirmSignUp = psConfirmSignUpInputField.text;

        if (string.IsNullOrEmpty(idSignUp) || string.IsNullOrEmpty(nameSignUp) || string.IsNullOrEmpty(psSignUp) || string.IsNullOrEmpty(psConfirmSignUp))
        {
            confirmText.text = "모든 항목을 입력해주세요.";
            return;
        }

        if (psSignUp != psConfirmSignUp)
        {
            confirmText.text = "비밀번호가 일치하지 않습니다.";
            return;
        }

        if(GameManager.Instance.LoadUserData(idSignUp) != null)
        {
            confirmText.text = "이미 존재하는 아이디입니다";
            return;
        }

        GameManager.Instance.SignUpUserData(idSignUp, nameSignUp, psSignUp);

    }

    private void ErrorClose()
    {
        errorPanel.gameObject.SetActive(false);
    }

}
