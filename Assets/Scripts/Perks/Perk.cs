using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void BuyPerk() {
        if(!isBought && Score.score >= price) {
            isBought = true;
            Score.score -= price;
            ApplyPerk();
        }
    }

    protected virtual void ApplyPerk() {
        Debug.Log("Perk Applied");
    }
}
