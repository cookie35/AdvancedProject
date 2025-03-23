using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupSignUp : MonoBehaviour
{
    public GameObject popupSignUp;

    [Header("SignUp")]
    public TMP_InputField idSignUpInputField;
    public TMP_InputField nameSignUpInputField;
    public TMP_InputField psSignUpInputField;
    public TMP_InputField psConfirmSignUpInputField;

    [Header("ErrorTxt")]
    public TMP_Text errorTxt;

    [Header("SignUp Buttons")]
    public Button cancelBtn;
    public Button signUpCompleteBtn;

    [Header("Other Popups")]
    public PopupError popupError;

    void Start()
    {
        psSignUpInputField.contentType = TMP_InputField.ContentType.Password;
        psConfirmSignUpInputField.contentType = TMP_InputField.ContentType.Password;

        cancelBtn.onClick.AddListener(Cancel);
        signUpCompleteBtn.onClick.AddListener(SignUpConfirm);
    }

    private void Cancel()
    {
        popupSignUp.SetActive(false);
    }

    private void SignUpConfirm()
    {
        string idSignUp = idSignUpInputField.text;
        string nameSignUp = nameSignUpInputField.text;
        string psSignUp = psSignUpInputField.text;
        string psConfirmSignUp = psConfirmSignUpInputField.text;

        if (string.IsNullOrEmpty(idSignUp) || string.IsNullOrEmpty(nameSignUp) || string.IsNullOrEmpty(psSignUp) || string.IsNullOrEmpty(psConfirmSignUp))
        {
            popupError.LoginInputEmptyError();
            return;
        }
        else if (GameManager.Instance.LoadUserData(idSignUp) != null)
        {
            popupError.IdExistError();
            return;
        }
        else if (GameManager.Instance.IsPasswordExist(psSignUp) == true)
        {
            popupError.PsExistError();
            return;
        }
        else if (psSignUp != psConfirmSignUp)
        {
            popupError.PsNotMatchError();
            return;
        }
        else
        {
            GameManager.Instance.SignUpUserData(idSignUp, nameSignUp, psSignUp);
            popupSignUp.SetActive(false);
        }


    }

}
