using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CHS
{

    public class Hero : Entity
    {
        #region Objects
        // Objects
        private Player player;

        #endregion

        #region Variables

        // Stats
        private int lives;
        private float luck;
        private float pvpBonus;
        private float healthPerLevel;
        private float healthRegenPerLevel;
        private float manaPerLevel;
        private float manaRegenPerLevel;
        private float damagePerLevel;
        private float armourPerLevel;
        private float magicResistPerLevel;
        private float attackSpeedPerLevel;
        private float magicPowerPerLevel;
        private Ability heroAbility;
        private float xp;

        #endregion


        #region Monobehaviour
        // Start is called before the first frame update
        private new void Start()
        {
            SubscribeEvents();
            base.Start();
        }

        // Update is called once per frame
        private new void Update()
        {
            base.Update();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        #endregion

        #region Functions

        private void SubscribeEvents()
        {
            player.mouse.PlayerMoved += Move;
        }

        private void UnsubscribeEvents()
        {
            player.mouse.PlayerMoved -= Move;
        }

        #endregion
    }
}
