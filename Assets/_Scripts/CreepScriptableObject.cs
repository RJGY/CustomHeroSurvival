using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHS {
    [CreateAssetMenu(fileName = "CreepEntity", menuName = "ScriptableObjects/CreepScriptableObject", order = 2)]
    public class CreepScriptableObject : BaseEntityScriptableObject
    {
        public float magicPower;
        public float physicalPower;
        public float evasion;
        public int level;
        public Ability[] abilities;
    }
}

