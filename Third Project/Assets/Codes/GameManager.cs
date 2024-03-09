using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject Pause;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            isPaused = true;
            Pause.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void play()
    {
        isPaused = false;
        SceneManager.LoadScene("TheGame");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Pause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
