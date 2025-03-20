using TMPro;
using UnityEngine;

// UI ���Ű� ���õ� ���� ���

public class ATMScreen : MonoBehaviour
{
    public GameObject atmWindow;  // �ν����� â���� �־� �� atmUi

    [Header("PopupBank")]
    public TextMeshProUGUI balance;  // ���� �ܰ� ����
    public TextMeshProUGUI cash; // ���� �ִ� ����
    public GameObject depositButton;  // �Ա� ��ư
    public GameObject withdrawButton;  // ��� ��ư
    
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        balance.text = $"{GameManager.Instance.userDataSO.balance:N0}";
        cash.text = $"{GameManager.Instance.userDataSO.cash:N0}";
    }
}
