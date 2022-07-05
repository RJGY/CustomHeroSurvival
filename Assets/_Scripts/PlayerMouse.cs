using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHS
{

    public class PlayerMouse : MonoBehaviour
    {
        #region Events
        public delegate void Position(Vector3 position);
        public event Position PlayerMoved;

        public delegate void Enemy(Entity enemy);
        public event Enemy EnemyAttacked;
        #endregion

        #region Variables
        // Variables
        private Player player;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask playerLayer;
        #endregion

        #region Monobehaviour
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RightMouseClickLogic();
            } else if (Input.GetMouseButtonDown(0)) {
                LeftMouseClickLogic();
            }
        }

        #endregion

        #region Functions

        private void RightMouseClickLogic()
        {

        }

        private void LeftMouseClickLogic()
        {

        }

        void MoveToPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                print("invoked");
                PlayerMoved?.Invoke(hit.point);
            }
        }

        void AttackEnemy()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerLayer))
            {
                EnemyAttacked?.Invoke(hit.collider.gameObject.GetComponent<Entity>());
            }
        }

        #endregion
    }
}