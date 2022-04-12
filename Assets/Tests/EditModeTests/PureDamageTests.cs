using System.Collections;
using System.Collections.Generic;
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
            // Use the Assert class to test conditions
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
    }
}
