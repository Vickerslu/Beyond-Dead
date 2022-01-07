using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zombie : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        agent.speed = speedMultiplier * UnityEngine.Random.Range(3f,4f);
        Debug.Log(speedMultiplier);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void IncreaseHealth(int multiplier)
    {
        base.hp = Convert.ToInt32(Math.Floor(300*(multiplier*0.3f)));
    }

    public override void DealDamage(Player player) {
        player.ReduceHp(40f);
    }
}
