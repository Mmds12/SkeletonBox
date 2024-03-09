using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static int playerHP = 100;
    public TextMeshProUGUI healthText;
    public GameObject gameOver;

    void Update()
    {
        healthText.text = playerHP.ToString();

        if (playerHP <= 0)
        {
            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
    }
    public static void takeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
    }

    public void Restart()
    {
        playerHP = 100;
        Cursor.lockState= CursorLockMode.Locked;
        Time.timeScale = 1f;
        Enemy.kills = 0;
        Enemy.money = 0;
        SceneManager.LoadScene("TheGame");
    }

    public void MainMenu()
    {
        playerHP = 100;
        Time.timeScale = 1f;
        Enemy.kills = 0;
        Enemy.money = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
