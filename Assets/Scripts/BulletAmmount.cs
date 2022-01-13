using UnityEngine;
using UnityEngine.UI;

public class BulletAmmount : MonoBehaviour
{
    public static int bullets = 0;
    public Text bulletsText;

    void Update()
    {
        bulletsText.text = "Bullets: " + PlayerController.ammo;
    }
}
