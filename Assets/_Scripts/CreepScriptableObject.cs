using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreepEntity", menuName = "ScriptableObjects/CreepScriptableObject", order = 2)]
public class CreepScriptableObject : BaseEntityScriptableObject
{
    public float magicPower;
    public float physicalPower;
    public float evasion;
    public int level;
    public float armorFlatPenetration;
    public float magicFlatPenetration;
    public float blockFlatPenetration;
    public float armorPercentPenetration;
    public float magicPercentPenetration;
    public float blockPercentPenetration;
}
