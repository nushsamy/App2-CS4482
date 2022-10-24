using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    public string mainMenu;
    public Transform respawnPoint;
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        TimerScript.timeRemaining = 120;
        SceneManager.LoadScene("Platformer");
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
