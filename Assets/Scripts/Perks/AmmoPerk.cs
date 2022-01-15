using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPerk : Perk
{
    protected override void Start() {
        base.Start();
        base.price = 100;
    }

    protected override void ApplyPerk() {
        base.player.BuyBullets();
    }
}