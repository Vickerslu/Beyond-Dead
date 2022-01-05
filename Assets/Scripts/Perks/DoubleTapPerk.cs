using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
