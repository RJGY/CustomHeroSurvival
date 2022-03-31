using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreepEntity", menuName = "ScriptableObjects/CreepScriptableObject", order = 2)]
public class CreepScriptableObject : BaseEntityScriptableObject
{
    public float magicPower;
    public float physicalPower;
    public float evasion;
    public float level;
    public float armorFlatPenetration;
    public float magicResistFlatPenetration;
    public float blockFlatPenetration;
    public float armorPercentPenetration;
    public float magicResistPercentPenetration;
    public float blockPercentPenetration;
}
