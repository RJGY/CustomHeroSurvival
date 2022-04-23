using System.Collections;
using System.Collections.Generic;
using CHS;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ElementalDamageTests
    {
        [Test]
        public void ElementalDamage_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithArmor_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithMagicResist_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithMagicResistAndFlatPen_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithMagicResistAndPercentPen_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithMagicResistAndBlock_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithBlock_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithBlockAndFlatPen_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithBlockAndPercentPen_ShouldDeal_ExpectedDamage()
        {
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
        public void ElementalDamageWithMagicPower_ShouldDeal_ExpectedDamage()
        {
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

        // Add elemental modifiers here

    }
}
