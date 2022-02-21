using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Stats
    private float currentHealth;
    private float maxHealth;
    private float healthRegen;
    private float maxMana;
    private float currentMana;
    private float manaRegen;
    private float attackDamage;
    private float baseAttackSpeed;
    private float attackSpeed;
    private float armorCoefficient = 20;
    private float magicResistCoefficient = 100;
    private float attackSpeedCap = 2.50F;
    private float armor;
    private float magicResist;
    private float magicPower;
    private float block;
    private float pvpBonus;
    private int level;
    private float xp;
    private float moveSpeed;
    private float luck;
    private float physicalPower;
    private float evasion;
    private float missChance;

    private float armorPercentPenetration;
    private float armorFlatPenetration;


    protected void Start()
    {
        
    }

    protected void Update()
    {
        
    }

    protected void Spawn()
    {

    }

    protected void Move(Vector2 destination)
    {

    }

    public void TakeDamage(DamageTypes damageType, float damageAmount, float flatPenetration, float percentagePenetration, float blockPenetration)
    {
        switch (damageType)
        {
            case DamageTypes.PhysicalDamage:
                currentHealth -= damageAmount;
                break;
            case DamageTypes.MagicDamage:
                currentHealth -= damageAmount;
                break;
            default:
                break;
        }
    }

    protected void Attack(Entity enemy)
    {
        enemy.TakeDamage(DamageTypes.PhysicalDamage, attackDamage, armorFlatPenetration, armorPercentPenetration, 0);
    }

    protected void Die()
    {

    }
}
