using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk : MonoBehaviour
{
    [SerializeField] protected bool isBought;
    [SerializeField] protected int price;
    protected GameObject playerObject;
    protected Player player;


    protected virtual void Start() {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    public void Buy() {
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
