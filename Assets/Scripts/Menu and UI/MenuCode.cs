using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuCode : MonoBehaviour
{
    public void Start(){

    }
    public void Update(){
        if (Keyboard.current.mKey.wasPressedThisFrame) {
            SceneManager.LoadScene("StartMenu");
        }
    }

    // Resets the main variables and reloads the game
    public void PlayGame()
    {
        Ship.repairProgress = 0;
        Score.score = 0;
        PartText.parts = 0;
        SceneManager.LoadScene("InGame");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void PlayTutorial()
    {
        Ship.repairProgress = 0;
        Score.score = 10000;
        PartText.parts = 0;
        SceneManager.LoadScene("Tutorial");
    }

    // Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
