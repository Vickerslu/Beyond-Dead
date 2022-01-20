using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Brute is a type of enemy. They are slower but deal a lot more damage and have a lot a knockback power
public class BruteZombie : Enemy
{
    // Parent's start method is called but a couple of variables are changed
    protected override void Start()
    {
        base.Start();
        knockbackPower = 1.5f;
        knockbackDuration = 3f;
        agent.speed = speedMultiplier * UnityEngine.Random.Range(3f,4f);
    }

    public override void IncreaseHealth(int multiplier) {
        base.maxHp = Convert.ToInt32(base.maxHp+(12*multiplier));
        base.hp = base.maxHp;
    }

    public override void DealDamage(Player player) {
        player.ReduceHp(75f);
    }
}
