using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BruteZombie : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // base.maxHp = 300;
        // base.hp = base.maxHp;
        agent.speed = speedMultiplier * UnityEngine.Random.Range(1f,2f);
    }

    public override void IncreaseHealth(int multiplier) {
        base.maxHp = Convert.ToInt32(base.maxHp+(12*multiplier));
        base.hp = base.maxHp;
    }

    public override void DealDamage(Player player) {
        player.ReduceHp(75f);
    }
}
