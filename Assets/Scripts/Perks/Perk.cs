using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a 'Perk' is a buyable upgrade to the player
public class Perk : MonoBehaviour
{
    [SerializeField] protected bool isBought;
    [SerializeField] protected int price;
    protected GameObject playerObject;
    protected Player player;
    protected PlayerController playerController;

    protected virtual void Start() {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        playerController = playerObject.GetComponent<PlayerController>();
    }

    // checks if the player has enough points to purchase the perk
    public void BuyPerk() {
        if(!isBought && Score.score >= price) {
            isBought = true;
            Score.score -= price;
            ApplyPerk();
        }
    }

    // code to be overwritten by children depending on what the perk does
    protected virtual void ApplyPerk() {
        Debug.Log("Perk Applied");
    }
}
