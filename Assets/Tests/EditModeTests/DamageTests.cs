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
        // A Test behaves as an ordinary method
        [Test]
        public void Set_DamageStats_ToEquivalentStats()
        {
            // Use the Assert class to test conditions
            GameObject gameObject = new GameObject();
            Entity entity = gameObject.AddComponent<Entity>();

            Assert.AreEqual(100.0f, entity.attackDamage);
        }
    }
}
