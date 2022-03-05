using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Btkalman.Util;

public class DamageOverTime : MonoBehaviour
{
    public Entity enemy { get; private set; }
    public string id { get; private set; }
    public DamageTypes damageType { get; private set; }
    public Entity damageDealer { get; private set; }
    public float damage { get; private set; }
    public float period { get; private set; }
    public int remainingStacks { get; private set; }
    public Timer timer { get; private set; }
    public int limit { get; private set; }

    public DamageOverTime(Entity enemy, string id, DamageTypes damageType, Entity damageDealer, float damage, float period, int remainingStacks, int limit)
    {
        this.enemy = enemy;
        this.id = id;
        this.damageType = damageType;
        this.damageDealer = damageDealer;
        this.period = period;
        this.remainingStacks = remainingStacks;
        this.limit = limit;
    }

    void Start()
    {
        timer = new Timer(0);
    }

    void Update()
    {
        if (timer.Update(Time.deltaTime))
        {
            damageDealer.DealDamage(damageType, damage, enemy);
            remainingStacks--;
            if (remainingStacks == 0)
            {
                Destroy(gameObject);
            }
            timer.Start();
        }
    }
}
