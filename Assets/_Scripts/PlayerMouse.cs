using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    #region Events
    public delegate void Position(Vector3 position);
    public event Position PlayerMoved;
    #endregion

    #region Variables
    // Variables
    private Player player;
    [SerializeField] private LayerMask groundLayer;

    #endregion


    #region Monobehaviour
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

    void MoveToPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            PlayerMoved?.Invoke(hit.point);
        }
    }

    #endregion
}
