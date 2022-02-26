using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Btkalman.Util;

public class DamageOverTime : MonoBehaviour
{
    public Entity enemy { get; private set; }
    public string id { get; private set; }
    private Entity damageDealer;
    private float damage;
    private float period;
    private int amount;
    private Timer timer;
    private int limit;

    void Start()
    {
        timer = new Timer(period);
    }

    void Update()
    {
        if (timer.Update(Time.deltaTime))
        {
            
        }
    }
}
