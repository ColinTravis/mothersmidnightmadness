using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public string mainMapScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start a new game
    public void NewGame()
    {
        SceneManager.LoadScene(mainMapScene);
    }

    // Quit the Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
