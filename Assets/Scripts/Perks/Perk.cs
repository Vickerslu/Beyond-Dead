using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk : MonoBehaviour
{
    public bool isBought;
    [SerializeField] protected int price;
    public Player player;

    public void Buy() {
        if(!isBought && Score.score >= price) {
            isBought = true;
            Score.score -= price;
            ApplyPerk();
        }
    }

    protected virtual void ApplyPerk() {
        Debug.Log("Noooooo not this one ");
    }
}
