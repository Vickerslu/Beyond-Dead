using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public static int repairProgress = 0;
    public GameObject ship;

    // Takes an integer and repairs the ship by this amount. Deals with what happens once the ship is fully rebuilt.
    public static void Repair(int amount)
    {
        repairProgress += amount;
        if(repairProgress >= 100) {
            SceneManager.LoadScene(3);
        }
    }
}