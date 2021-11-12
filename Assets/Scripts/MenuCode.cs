using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuCode : MonoBehaviour
{
    public Text pointsText;
    public void Start(){
        pointsText.text = Score.score.ToString() + " Points!";
        Debug.Log(pointsText.text);
    }    
    
    public void PlayGame()
    {
        Ship.repairProgress = 0;
        Score.score = 0;
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
