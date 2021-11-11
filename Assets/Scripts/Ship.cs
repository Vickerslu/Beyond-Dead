using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public static int repairProgress = 0;
    public GameObject ship;

    // Update is called once per frame
    public static void Repair(int amount)
    {
        repairProgress += amount;
        Debug.Log(repairProgress + " repair progress!");
        if(repairProgress >= 10) {
            SceneManager.LoadScene(3);
        }
    }
}