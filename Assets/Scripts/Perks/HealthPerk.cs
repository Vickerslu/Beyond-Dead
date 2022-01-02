using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPerk : Perk
{
    private void Start() {
        base.price = 180;
    }

    protected override void ApplyPerk() {
        Debug.Log("Appliedddddddd");
        base.player.AssignHealthPerk();
    }
}
