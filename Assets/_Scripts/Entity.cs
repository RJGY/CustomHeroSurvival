using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    // Objects
    protected NavMeshAgent agent;

    // Stats
    protected float currentHealth;
    protected float maxHealth;
    protected float healthRegen;
    protected float maxMana;
    protected float currentMana;
    protected float manaRegen;
    protected float attackDamage;
    protected float baseAttackSpeed;
    protected float attackSpeed;
    protected float armorCoefficient = 20;
    protected float magicResistCoefficient = 100;
    protected float attackSpeedCap = 2.50F;
    protected float armor;
    protected float magicResist;
    protected float magicPower;
    protected float block;
    protected float pvpBonus;
    protected int level;
    protected float xp;
    protected float moveSpeed;
    protected float physicalPower;
    protected float evasion;
    protected float missChance;
    protected bool isMelee;
    protected float attackRange;
    protected float armorPercentPenetration;
    protected float armorFlatPenetration;
    protected float magicPercentPenetration;
    protected float magicFlatPenetration;
    protected float blockPercentPenetration;
    protected float blockFlatPenetration;
    protected float damageReduction;
    protected Ability[] abilities;
    protected bool canAttack;

    protected void Start()
    {
        
    }

    protected void Update()
    {
        
        
    }

    protected void Spawn()
    {

    }

    protected void Attack(Entity enemy)
    {

    }

    protected void RegenerateHealth()
    {
        currentHealth += healthRegen * Time.deltaTime;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(DamageTypes damageType, float damageAmount, float flatPenetration, float percentagePenetration, float blockFlatPenetration, float blockPercentPenetration)
    {
        float effectiveBlock;
        float effectiveArmorType;
        switch (damageType)
        {
            case DamageTypes.PhysicalDamage:
                effectiveArmorType = armor * (1 - percentagePenetration) - flatPenetration;
                effectiveBlock = block * (1 - blockPercentPenetration) - blockFlatPenetration;
                currentHealth -= (damageAmount - effectiveBlock) * (effectiveArmorType / (effectiveArmorType + armorCoefficient)) * (1 - damageReduction);
                break;
            case DamageTypes.MagicDamage:
                effectiveArmorType = magicResist * (1 - percentagePenetration) - flatPenetration;
                effectiveBlock = block * (1 - blockPercentPenetration) - blockFlatPenetration;
                currentHealth -= damageAmount * (effectiveArmorType / (effectiveArmorType + armorCoefficient)) * (1 - damageReduction) - effectiveBlock;
                break;
            case DamageTypes.ElementalDamage:
                effectiveArmorType = magicResist * (1 - percentagePenetration) - flatPenetration;
                effectiveBlock = block * (1 - blockPercentPenetration) - blockFlatPenetration;
                currentHealth -= damageAmount * (effectiveArmorType / (effectiveArmorType + armorCoefficient)) * (1 - damageReduction) - effectiveBlock;
                break;
            case DamageTypes.PureDamage:
                currentHealth -= damageAmount;
                break;
            default:
                break;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void DealDamage(DamageTypes damageType, float damageAmount, Entity enemy)
    {
        switch (damageType)
        {
            case DamageTypes.PhysicalDamage:
                enemy.TakeDamage(DamageTypes.PhysicalDamage, damageAmount, armorFlatPenetration, armorPercentPenetration, blockFlatPenetration, blockPercentPenetration);
                break;
            case DamageTypes.MagicDamage:
                enemy.TakeDamage(DamageTypes.MagicDamage, damageAmount, magicFlatPenetration, magicPercentPenetration, blockFlatPenetration, blockPercentPenetration);
                break;
            case DamageTypes.ElementalDamage:
                enemy.TakeDamage(DamageTypes.ElementalDamage, damageAmount, magicFlatPenetration, magicPercentPenetration, blockFlatPenetration, blockPercentPenetration);
                break;
            case DamageTypes.PureDamage:
                enemy.TakeDamage(DamageTypes.PureDamage, damageAmount, 0, 0, 0, 0);
                break;
            default:
                break;
        }
    }

    protected void BasicAttack(Entity enemy)
    {
        if (canAttack)
        {
            DealDamage(DamageTypes.PhysicalDamage, attackDamage, enemy);
        }
    }

    private void GetComponentsOnStart()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected void Move(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    protected void AttackCooldown()
    {
        
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
