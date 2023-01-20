using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHS
{
    public class Creep : Entity
    {
        #region Variables
        private Hero assignedHero;
        #endregion

        #region Monobehaviour
        private new void Update() {
            base.Update();
            if (assignedHero != null)
            {
                SeekHero();
            }
        }
        #endregion


        #region Functions
        private void SeekHero()
        {
            Attack(assignedHero);
        }


        public void AssignStats(CreepScriptableObject creep)
        {
            level = creep.level;
            physicalPower = creep.physicalPower;
            magicPower = creep.magicPower;
            evasion = creep.evasion;
            base.AssignStats(creep);
        }

        #endregion
    }
}