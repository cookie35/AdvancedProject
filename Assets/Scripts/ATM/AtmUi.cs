using TMPro;
using UnityEngine;

// UI ���Ű� ���õ� ���� ���

public class AtmUi : MonoBehaviour
{
    public GameObject atmWindow;  // �ν����� â���� �־� �� atmUi

    [Header("PopupBank")]
    public TextMeshProUGUI cashTxt; // ��ũ���� ǥ�õǴ� ���� �ܰ� (�ؽ�Ʈ)
    public TextMeshProUGUI balanceTxt;  // ��ũ���� ǥ�õǴ� ���� �ܰ� (�ؽ�Ʈ)
    public GameObject depositButton;  // �Ա� ��ư
    public GameObject withdrawButton;  // ��� ��ư
    
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        balanceTxt.text = $"{GameManager.Instance.userData.balanceInt:N0}";
        cashTxt.text = $"{GameManager.Instance.userData.cashInt:N0}";
    }

}
