using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    #region Variables
    // Stats
    private int gold;
    private int glory;
    private int income;
    private int creepLevel;
    private Hero hero;
    private PlayerMouse mouse;
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

    void GetComponentsOnStart()
    {
        
    }

    void Move(Vector3 position)
    {
        hero.Move(position);
    }

    #endregion

}
