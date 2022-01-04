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
        agent.speed = UnityEngine.Random.Range(7f,9f);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void IncreaseHealth(int multiplier)
    {
        base.hp = Convert.ToInt32(Math.Floor(50*(multiplier*0.3f)));
    }

    public override void DealDamage(Player player) {
        player.ReduceHp(20f);
    }
}
