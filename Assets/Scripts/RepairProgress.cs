using UnityEngine;
using UnityEngine.UI;

public class RepairProgress : MonoBehaviour
{
    public Text repairProgress;

    void Update()
    {
        repairProgress.text = ("Repaired: " + Ship.repairProgress.ToString() + "%");
    }
}
