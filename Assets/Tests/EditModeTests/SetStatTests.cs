using System.Collections;
using System.Collections.Generic;
using CHS;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SetStatTests
    {
        #region SetStats
        [Test]
        public void Set_AttackDamage_ToEquivalentStats()
        {
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.attackDamage = 100.0f;
            entity.AssignStats(stats);

            Assert.AreEqual(100.0f, entity.attackDamage);
        }

        [Test]
        public void Set_BaseAttackSpeed_ToEquivalentStats()
        {
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.baseAttackSpeed = 110.0f;
            entity.AssignStats(stats);

            Assert.AreEqual(110.0f, entity.baseAttackSpeed);
        }

        [Test]
        public void Set_FinalAttackSpeed_ToEquivalentStats()
        {
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.attackSpeed = 101.0f;
            entity.AssignStats(stats);

            Assert.AreEqual(101.0f, entity.attackSpeed);
        }

        [Test]
        public void Set_AttackRange_ToEquivalentStats()
        {
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.attackRange = 100.1f;
            entity.AssignStats(stats);

            Assert.AreEqual(100.1f, entity.attackRange);
        }

        [Test]
        public void Set_IsMelee_ToEquivalentStats()
        {
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();
            BaseEntityScriptableObject stats = ScriptableObject.CreateInstance<BaseEntityScriptableObject>();
            stats.isMelee = true;
            entity.AssignStats(stats);

            Assert.IsTrue(entity.isMelee);
        }

        #endregion
    }
}
