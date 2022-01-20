using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'double tap' makes the player shoot at double the fire rate, essentially doing double the damage
public class DoubleTapPerk : Perk
{
    protected override void Start() {
        base.Start();
        base.price = 2000;
    }

    protected override void ApplyPerk() {
        base.player.AssignDoubleTapPerk();
    }
}
