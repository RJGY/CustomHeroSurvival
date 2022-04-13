using System.Collections;
using System.Collections.Generic;
using CHS;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MagicDamageTests
    {
        #region MagicDamageTests

        [Test]
        public void MagicDamage_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithArmor_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.armor = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.armor);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithMagicResist_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.magicResist = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.magicResist);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithMagicResistAndFlatPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.magicResist = 100.0f;
            stats.magicFlatPenetration = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.magicResist);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithMagicResistAndPercentPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.magicResist = 200.0f;
            stats.magicPercentPenetration = 0.5f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.magicResist);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithMagicResistAndBlock_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.magicResist = 100.0f;
            stats.block = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.magicResist);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(1000.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithBlock_ShouldDeal_ExpectedDamage()
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
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(900.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithBlockAndFlatPen_ShouldDeal_ExpectedDamage()
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
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithBlockAndPercentPen_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.block = 100.0f;
            stats.blockPercentPenetration = 0.5f;
            entity.SetStats(stats);

            Assert.AreEqual(100.0f, entity.block);
            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(850.0f, entity.currentHealth);
        }

        [Test]
        public void MagicDamageWithMagicPower_ShouldDeal_ExpectedDamage()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.magicPower = 1.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.MagicDamage, entity.attackDamage, entity);
            Assert.AreEqual(600.0f, entity.currentHealth);
        }

        #endregion
    }
}
