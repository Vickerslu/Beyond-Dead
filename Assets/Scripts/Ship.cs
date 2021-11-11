using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public static int repairProgress = 0;
    public GameObject ship;

    // Update is called once per frame
    public static void Repair(int amount)
    {
        repairProgress += amount;
        Debug.Log(repairProgress + " repair progress!");
        if(repairProgress >= 100) {
            //do something
        }
    }
}