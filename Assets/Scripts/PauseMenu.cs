using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    

    //If we press the escape button or the back button in android then the pausemenu is gonna show up
    void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //If we press resume then the menu panel dissapears and we keep going playing
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //If we press the pause button then we set the timescale to 0 .
   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //If we press the main menu button then we return to the main menu scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(AudioManager.instance.gameObject);
        Destroy(GameMaster.instance.gameObject);
        SceneManager.LoadScene("Menu");
    }
    
    //If we press the quit button then we close the application
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
