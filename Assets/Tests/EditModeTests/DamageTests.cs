using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CHS;
namespace Tests
{
    public class DamageTest
    {
        [Test]
        public void Set_AttackDamage_ToEquivalentStats()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.attackDamage = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.attackDamage);
        }

        [Test]
        public void Set_BaseAttackSpeed_ToEquivalentStats()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.baseAttackSpeed = 110.0f;
            entity.SetStats(stats);

            Assert.AreEqual(110.0f, entity.baseAttackSpeed);
        }

        [Test]
        public void Set_FinalAttackSpeed_ToEquivalentStats()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.attackSpeed = 101.0f;
            entity.SetStats(stats);

            Assert.AreEqual(101.0f, entity.attackSpeed);
        }

        [Test]
        public void Set_AttackRange_ToEquivalentStats()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.attackRange = 100.1f;
            entity.SetStats(stats);

            Assert.AreEqual(100.1f, entity.attackRange);
        }

        [Test]
        public void Set_IsMelee_ToEquivalentStats()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.isMelee = true;
            entity.SetStats(stats);

            Assert.IsTrue(entity.isMelee);
        }
        
        [Test]
        public void TakeDamage_ShouldTake_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 100.0f;
            entity.SetStats(stats);
            Assert.AreEqual(100.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);

            entity.TakeDamage(DamageTypes.PhysicalDamage, entity.attackDamage, 0, 0, 0, 0);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        [Test]
        public void BasicAttack_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.attackDamage);
            Assert.AreEqual( 1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        [Test]
        public void BasicAttackWithArmour_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.armor = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.armor);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        // ADD CREEP STUFF
        [Test]
        public void BasicAttackWithArmourAndArmourPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.armor = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.armor);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }
    }
}
