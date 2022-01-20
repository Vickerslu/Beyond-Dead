using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'Hp regen' perk increases the rate in which the players health regenerates
public class HpRegenPerk : Perk
{
    protected override void Start() {
        base.Start();
        base.price = 2500;
    }

    protected override void ApplyPerk() {
        base.player.AssignHpRegenPerk();
    }
}
