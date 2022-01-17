using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FastZombie : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // base.maxHp = 75;
        // base.hp = base.maxHp;
        agent.speed = speedMultiplier * UnityEngine.Random.Range(7f,9f);
    }

    public override void IncreaseHealth(int multiplier) {
        base.maxHp = Convert.ToInt32(base.maxHp+(8*multiplier));
        base.hp = base.maxHp;
    }

    public override void DealDamage(Player player) {
        player.ReduceHp(20f);
    }
}
