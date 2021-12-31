using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkController : MonoBehaviour
{
    public bool isBought;

    public void Buy() {
        Debug.Log("Ran Buy function in PerkController");
        if(!isBought) {
            isBought = true;
            Debug.Log("Perk Bought");
        }
    }
}
