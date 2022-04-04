using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHS
{
    public class Creep : Entity
    {
        #region Variables

        #endregion

        #region Monobehaviour

        #endregion


        #region Functions

        public void SetStats(CreepScriptableObject creep)
        {
            magicPower = creep.magicPower;
            physicalPower = creep.physicalPower;
            evasion = creep.evasion;
            level = creep.level;
            armorFlatPenetration = creep.armorFlatPenetration;
            magicFlatPenetration = creep.magicFlatPenetration;
            blockFlatPenetration = creep.blockFlatPenetration;
            armorPercentPenetration = creep.armorPercentPenetration;
            magicPercentPenetration = creep.magicPercentPenetration;
            blockPercentPenetration = creep.blockPercentPenetration;
            base.SetStats(creep);
        }

        #endregion
    }
}