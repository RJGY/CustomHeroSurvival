﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHS {
    [CreateAssetMenu(fileName = "BaseEntity", menuName = "ScriptableObjects/BaseEntityScriptableObject", order = 1)]
    public class BaseEntityScriptableObject : ScriptableObject
    {
        public float currentHealth;
        public float maxHealth;
        public float healthRegen;
        public float maxMana;
        public float currentMana;
        public float manaRegen;
        public float attackDamage;
        public float baseAttackSpeed;
        public float attackSpeed;
        public float armor;
        public float magicResist;
        public float moveSpeed;
        public bool isMelee;
        public float attackRange;
        public float block;
        public float armorPercentPenetration;
        public float armorFlatPenetration;
        public float magicPercentPenetration;
        public float magicFlatPenetration;
        public float blockPercentPenetration;
        public float blockFlatPenetration;
        
    }
}
