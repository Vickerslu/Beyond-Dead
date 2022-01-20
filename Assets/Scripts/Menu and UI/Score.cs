using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 100000;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
