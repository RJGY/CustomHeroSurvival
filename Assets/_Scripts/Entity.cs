using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Btkalman.Util;

namespace CHS
{

    public class Entity : MonoBehaviour
    {
        #region Objects
        // Objects
        public NavMeshAgent agent { get; protected set; }
        public Entity currentEnemy { get; protected set; }
        public Collider body { get; protected set; }
        public Timer attackCooldown { get; protected set; }

        #endregion

        #region Variables
        // Stats
        public float currentHealth { get; protected set; }
        public float maxHealth { get; protected set; }
        public float healthRegen { get; protected set; }
        public float maxMana { get; protected set; }
        public float currentMana { get; protected set; }
        public float manaRegen { get; protected set; }
        public float attackDamage { get; protected set; }
        public float baseAttackSpeed { get; protected set; }
        public float attackSpeed { get; protected set; }
        private float armorCoefficient = 100;
        private float attackSpeedCap = 2.50f;
        public float armor { get; protected set; }
        public float magicResist { get; protected set; }
        public float magicPower { get; protected set; }
        public float block { get; protected set; }
        public int level { get; protected set; }
        public float moveSpeed { get; protected set; }
        public float physicalPower { get; protected set; }
        public float evasion { get; protected set; }
        public float missChance { get; protected set; }
        public bool isMelee { get; protected set; }
        public float attackRange { get; protected set; }
        public float armorPercentPenetration { get; protected set; }
        public float armorFlatPenetration { get; protected set; }
        public float magicPercentPenetration { get; protected set; }
        public float magicFlatPenetration { get; protected set; }
        public float blockPercentPenetration { get; protected set; }
        public float blockFlatPenetration { get; protected set; }
        public float damageReduction { get; protected set; }
        public Ability[] abilities { get; protected set; }
        public Buff[] buffs { get; protected set; }
        public bool canAttack { get; protected set; }
        public bool isVisible { get; protected set; }
        #endregion

        #region Monobehaviour

        protected void Awake() 
        {
            AssignObjects();
        }

        protected void Start() {

        }

        protected void Update() {
            AttackCooldown(Time.deltaTime);
        }

        #endregion

        #region Functions
        protected void RegenerateHealth()
        {
            if (currentHealth >= maxHealth)
                return;

            currentHealth += healthRegen * Time.deltaTime;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }

        protected void CheckCurrentEnemy()
        {
            if (!currentEnemy.isVisible)
            {
                currentEnemy = null;
            }
        }

        public void TakeDamage(DamageTypes damageType, float damageAmount, float flatPenetration, float percentagePenetration, float blockFlatPenetration, float blockPercentPenetration, bool isAutoAttack)
        {
            float effectiveBlock;
            float effectiveArmorType;
            if (isAutoAttack) {
                if (evasion >= Random.Range(0.0f, 100.0f)) {
                    return;
                }
            }

            switch (damageType)
            {
                case DamageTypes.PhysicalDamage:
                    effectiveArmorType = armor * (1 - percentagePenetration) - flatPenetration;
                    effectiveBlock = block * (1 - blockPercentPenetration) - blockFlatPenetration;
                    currentHealth -= Mathf.Max(damageAmount - effectiveBlock, 1) * (1 - (effectiveArmorType / (effectiveArmorType + armorCoefficient))) * (1 - Mathf.Min(damageReduction, 1));
                    break;
                case DamageTypes.MagicDamage:
                    effectiveArmorType = magicResist * (1 - percentagePenetration) - flatPenetration;
                    effectiveBlock = block * (1 - blockPercentPenetration) - blockFlatPenetration;
                    currentHealth -= Mathf.Max(damageAmount - effectiveBlock, 1) * (1 - (effectiveArmorType / (effectiveArmorType + armorCoefficient))) * (1 - Mathf.Min(damageReduction, 1));
                    break;
                case DamageTypes.ElementalDamage:
                    effectiveArmorType = magicResist * (1 - percentagePenetration) - flatPenetration;
                    effectiveBlock = block * (1 - blockPercentPenetration) - blockFlatPenetration;
                    currentHealth -= Mathf.Max(damageAmount - effectiveBlock, 1) * (1 - (effectiveArmorType / (effectiveArmorType + armorCoefficient))) * (1 - Mathf.Min(damageReduction, 1));
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

        public void DealDamage(DamageTypes damageType, float damageAmount, Entity enemy) {
            DealDamage(damageType, damageAmount, enemy, false);
        }

        public void DealDamage(DamageTypes damageType, float damageAmount, Entity enemy, bool isAutoAttack)
        {
            if (isAutoAttack) {
                if (missChance >= Random.Range(0.0f, 100.0f)) {
                    return;
                }
            }

            switch (damageType)
            {
                case DamageTypes.PhysicalDamage:
                    damageAmount *= 1.0f + physicalPower;
                    enemy.TakeDamage(DamageTypes.PhysicalDamage, damageAmount, armorFlatPenetration, armorPercentPenetration, blockFlatPenetration, blockPercentPenetration, isAutoAttack);
                    break;
                case DamageTypes.MagicDamage:
                    damageAmount *= 1.0f + magicPower;
                    enemy.TakeDamage(DamageTypes.MagicDamage, damageAmount, magicFlatPenetration, magicPercentPenetration, blockFlatPenetration, blockPercentPenetration, isAutoAttack);
                    break;
                case DamageTypes.ElementalDamage:
                    damageAmount *= 1.0f + magicPower;
                    // TODO: add elemental damage multipliers here.
                    enemy.TakeDamage(DamageTypes.MagicDamage, damageAmount, magicFlatPenetration, magicPercentPenetration, blockFlatPenetration, blockPercentPenetration, isAutoAttack);
                    break;
                case DamageTypes.PureDamage:
                    enemy.TakeDamage(DamageTypes.PureDamage, damageAmount, 0, 0, 0, 0, isAutoAttack);
                    break;
                default:
                    Debug.LogError("Default should not occur. DamageType: " + damageType);
                    break;
            }
        }

        protected void Attack(Entity enemy)
        {
            currentEnemy = enemy;

            if (Vector3.Distance(transform.position, enemy.transform.position) > attackRange)
            {
                Move(enemy.transform.position);
                return;
            }

            if (canAttack)
            {
                if (isMelee)
                {
                    // Play Attack Animation
                    DealDamage(DamageTypes.PhysicalDamage, attackDamage, enemy, true);
                    ToggleAttack();
                }
                else
                {
                    // Play Ranged Attack Animation
                    ToggleAttack();
                }
            }
        }

        protected void ManageBuffs(float deltaTime) {
            
        }

        protected void AssignObjects()
        {
            agent = GetComponent<NavMeshAgent>();
            attackCooldown = new Timer(attackSpeed);
        }

        protected void Move(Vector3 destination)
        {
            agent.SetDestination(destination);
        }

        protected void AttackCooldown(float deltaTime)
        {
            if (!canAttack && attackCooldown.Update(deltaTime))
            {
                canAttack = true;
            }
        }

        protected void ToggleAttack()
        {
            canAttack = false;
            attackCooldown.Start();
        }

        protected void Die()
        {
            Destroy(gameObject);
        }

        public void AssignStats(BaseEntityScriptableObject baseEntity)
        {
            armor = baseEntity.armor;
            attackDamage = baseEntity.attackDamage;
            attackRange = baseEntity.attackRange;
            currentHealth = baseEntity.currentHealth;
            maxHealth = baseEntity.maxHealth;
            healthRegen = baseEntity.healthRegen;
            maxMana = baseEntity.maxMana;
            attackSpeed = baseEntity.attackSpeed;
            baseAttackSpeed = baseEntity.baseAttackSpeed;
            magicResist = baseEntity.magicResist;
            moveSpeed = baseEntity.moveSpeed;
            isMelee = baseEntity.isMelee;
            block = baseEntity.block;
            blockFlatPenetration = baseEntity.blockFlatPenetration;
            blockPercentPenetration = baseEntity.blockPercentPenetration;
            armorFlatPenetration = baseEntity.armorFlatPenetration;
            armorPercentPenetration = baseEntity.armorPercentPenetration;
            magicFlatPenetration = baseEntity.magicFlatPenetration;
            magicPercentPenetration = baseEntity.magicPercentPenetration;
        }

        #endregion
    }
}