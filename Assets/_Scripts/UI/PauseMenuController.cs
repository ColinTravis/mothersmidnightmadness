using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    public string mainMenuScene;
    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        print("Paused");
        Time.timeScale = 0f;
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

}
