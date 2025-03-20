using UnityEngine;

public class ATMInteract : MonoBehaviour
{
    public GameObject atmUI;

    void Start()
    {
        if (atmUI != null)
            atmUI.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            atmUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            atmUI.SetActive(false);
        }
    }

}
