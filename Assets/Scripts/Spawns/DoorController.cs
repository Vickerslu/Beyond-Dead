using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] public int price;
    [SerializeField] private GameObject door;

    public void Awake() {
        price = 500;
    }

    public void BuyDoor()
    {
        if(Score.score >= price) {
            Score.score -= price;
            door.SetActive(false);
        }
    }
}
