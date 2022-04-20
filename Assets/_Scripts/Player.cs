using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CHS
{

    public class Player : MonoBehaviour
    {
        #region Events

        #endregion

        #region Variables
        // Stats
        public int gold { get; private set; }
        public int glory { get; private set; }
        public int income { get; private set; }
        public int creepLevel { get; private set; }
        public Hero hero { get; private set; }
        public PlayerMouse mouse { get; private set; }
        #endregion

        #region MonoBehaviour
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion

        #region Functions

        private void GetComponentsOnStart()
        {
            mouse = GetComponent<PlayerMouse>();
        }

        #endregion

    }
}
