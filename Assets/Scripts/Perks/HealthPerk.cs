using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'Health' perk increases the players max health, allowing them to take more damage before dying
public class HealthPerk : Perk
{
    protected override void Start() {
        base.Start();
        base.price = 2500;
    }

    protected override void ApplyPerk() {
        base.player.AssignHealthPerk();
    }
}
