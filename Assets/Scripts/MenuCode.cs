using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuCode : MonoBehaviour
{

    public void Start(){
        // Text pointsText = new Text();
        // pointsText.text = Score.score.ToString() + " Points!";
    }    
    
    // Resets the main variables and reloads the game
    public void PlayGame()
    {
        Ship.repairProgress = 0;
        Score.score = 0;
        SceneManager.LoadScene(1);
    }
    
    // Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
