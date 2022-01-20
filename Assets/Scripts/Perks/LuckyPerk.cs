using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 'Lucky' perk doubles the chances of an enemy dropping a part
public class LuckyPerk : Perk
{
    protected override void Start() {
        base.Start();
        base.price = 5000;
    }

    protected override void ApplyPerk() {
        Enemy.dropRate = (int)Math.Floor(Enemy.dropRate*0.5f);
    }
}
