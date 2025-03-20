using UnityEngine;
using UnityEngine.SceneManagement;

public class UiGameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    private Vector3 playerStartPosition;
    private Quaternion playerStartRotation;
    private PlayerCondition playerCondition;

    private void Start()
    {
        gameOverUI.SetActive(false);
        playerCondition = FindObjectOfType<PlayerCondition>();
        playerStartPosition = playerCondition.transform.position;
        playerStartRotation = playerCondition.transform.rotation;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverUI.SetActive(false);

        playerCondition.transform.position = playerStartPosition;
        playerCondition.transform.rotation = playerStartRotation;
        playerCondition.uiCondition.health.SetValue(playerCondition.uiCondition.health.maxValue);
        playerCondition.uiCondition.stamina.SetValue(playerCondition.uiCondition.stamina.maxValue);

        SceneManager.LoadScene("GameScene");
    }
}
