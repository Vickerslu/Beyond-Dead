using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'Speed' perk increases the speed at which the player wlaks and sprints
public class SpeedPerk : Perk
{
    protected override void Start() {
        base.Start();
        base.price = 2000;
    }

    protected override void ApplyPerk() {
        base.playerController.AssignSpeedPerk();
    }
}
