using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Events
    public delegate void DealDamage(float damage, Entity enemy, DamageTypes type);
    public DealDamage DamageDealt;
    #endregion

    #region Variables
    private float speed;
    private float damage;
    private LayerMask enemyLayer;
    private DamageTypes type;
    #endregion

    #region Monobehaviour
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.layer == enemyLayer))
            return;

        Entity enemy = collision.gameObject.GetComponent<Entity>();
        DamageDealt?.Invoke(damage, enemy, type);
    }
    #endregion

    #region Functions

    #endregion
}
