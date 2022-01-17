using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private bool left;
    [SerializeField]
    private bool right;

    #region Left Right UI Event Trigger 
    public void LeftDown()
    {
        left = true;
        right = false;
    }

    public void RightDown()
    {
        right = true;
        left = false;
    }

    public void LeftUp()
    {
        left = false;
    }

    public void RightUp()
    {
        right = false;
    }
    #endregion

    #region  Player Move Check Bool Return Method
    public bool LeftMove()
    {
        return left;
    }

    public bool RightMove()
    {
        return right;
    }
    #endregion
}
