using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHS
{

    [CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObjects/Ability", order = 4)]
    public class AbilityScriptableObject : ScriptableObject
    {
        public float currentHealth;
    }
}
