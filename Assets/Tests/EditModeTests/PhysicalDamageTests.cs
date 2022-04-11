using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CHS;
namespace Tests
{
    public class PhysicalDamageTest
    {
        

        #region PhysDamageTests

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
        public void BasicAttackWithMagicResist_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 100.0f;
            stats.magicResist = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            Assert.AreEqual(100.0f, entity.magicResist);
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

        [Test]
        public void BasicAttackWithArmourAndArmourFlatPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.armor = 100.0f;
            stats.armorFlatPenetration = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.armor);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void BasicAttackWithArmorAndArmorPercentPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.armor = 200.0f;
            stats.armorPercentPenetration = 0.5f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.armor);
            Assert.AreEqual(0.5f, entity.armorPercentPenetration);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        [Test]
        public void BasicAttackWithBlock_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.block = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.block);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }


        [Test]
        public void BasicAttackWithBlockAndArmour_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.block = 100.0f;
            stats.armor = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.block);
            Assert.AreEqual(100.0f, entity.armor);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(950.0f, entity.currentHealth);
        }

        [Test]
        public void BasicAttackWithBlockAndBlockFlatPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.block = 100.0f;
            stats.blockFlatPenetration = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.block);
            Assert.AreEqual(100.0f, entity.blockFlatPenetration);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void BasicAttackWithBlockAndBlockPercentPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.block = 200.0f;
            stats.blockPercentPenetration = 0.5f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.block);
            Assert.AreEqual(0.5f, entity.blockPercentPenetration);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PhysicalDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        #endregion

        
    }
}
