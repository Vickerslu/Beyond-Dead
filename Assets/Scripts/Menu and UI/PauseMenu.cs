using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    void Update()
    {
        // if (Keyboard.current.escapeKey.wasPressedThisFrame){
        //     if (GameIsPaused) {
        //         Resume();
        //     } else {
        //         Pause();
        //     }
        // }
        if (Keyboard.current.mKey.wasPressedThisFrame) {
            SceneManager.LoadScene("StartMenu");
        }
    }
    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    void Pause(){
        GameIsPaused = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.00000001f;
    }

    public void loadMenu() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame() {
        GameIsPaused = false;
        Application.Quit();
    }
}
