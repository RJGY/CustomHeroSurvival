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
        [SerializeField] private Player player;

        #endregion

        #region Variables

        // Stats
        [SerializeField] private int lives;
        [SerializeField] private float luck;
        [SerializeField] private float pvpBonus;
        [SerializeField] private float healthPerLevel;
        [SerializeField] private float healthRegenPerLevel;
        [SerializeField] private float manaPerLevel;
        [SerializeField] private float manaRegenPerLevel;
        [SerializeField] private float damagePerLevel;
        [SerializeField] private float armourPerLevel;
        [SerializeField] private float magicResistPerLevel;
        [SerializeField] private float attackSpeedPerLevel;
        [SerializeField] private float magicPowerPerLevel;
        [SerializeField] private Ability heroAbility;
        [SerializeField] private float xp;

        #endregion


        #region Monobehaviour
        // Start is called before the first frame update
        private new void Start()
        {
            
            SubscribeEvents();
            base.Start();
        }

        private void Awake()
        {
            AssignObjects();
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

        private void AssignObjects()
        {
            player = GetComponent<Player>();
        }

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
