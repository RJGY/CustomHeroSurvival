using System.Collections;
using System.Collections.Generic;
using CHS;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PureDamageTests
    {
        [Test]
        public void PureDamage_ShouldDeal_ExpectedDamage()
        {
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PureDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void PureDamageWithArmour_ShouldDeal_ExpectedDamage()
        {
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.armor = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(100.0f, entity.armor);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PureDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void PureDamageWithMagicResist_ShouldDeal_ExpectedDamage()
        {
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.magicResist = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(100.0f, entity.magicResist);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PureDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void PureDamageWithBlock_ShouldDeal_ExpectedDamage()
        {
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.block = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(100.0f, entity.block);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PureDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }


        [Test]
        public void PureDamageWithArmourAndBlockAndMagicResist_ShouldDeal_ExpectedDamage()
        {
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.block = 100.0f;
            stats.armor = 100.0f;
            stats.magicResist = 100.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(100.0f, entity.block);
            Assert.AreEqual(100.0f, entity.armor);
            Assert.AreEqual(100.0f, entity.magicResist);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PureDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }

        [Test]
        public void PureDamageWithPhysicalAndMagicPower_ShouldDeal_ExpectedDamage()
        {
            GameObject gameObject = new GameObject();
            Creep entity = gameObject.AddComponent<Creep>();
            CreepScriptableObject stats = ScriptableObject.CreateInstance<CreepScriptableObject>();
            stats.currentHealth = 1000.0f;
            stats.attackDamage = 200.0f;
            stats.physicalPower = 1.0f;
            stats.magicPower = 1.0f;
            entity.SetStats(stats);

            Assert.AreEqual(200.0f, entity.attackDamage);
            Assert.AreEqual(1000.0f, entity.currentHealth);
            entity.DealDamage(DamageTypes.PureDamage, entity.attackDamage, entity);
            Assert.AreEqual(800.0f, entity.currentHealth);
        }
    }
}
