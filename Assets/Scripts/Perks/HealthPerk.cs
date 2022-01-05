using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
