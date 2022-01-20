using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'Stamina up' perk increases the players maximum stamina, allowing them to sprint for longer durations
public class StaminUpPerk : Perk
{
    protected override void Start() {
        base.Start();
        base.price = 2000;
    }

    protected override void ApplyPerk() {
        base.player.AssignStaminaPerk();
    }
}
