using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Variable
    private Ray ray;

    private Vector3 directPos;
    private bool attack;
    private bool dive;

    // Property 
    [HideInInspector]
    public Vector3 DirectPos { get { return directPos; } }
    public bool Attack { get {return attack;} set { attack = value; } }
    public bool Dive { get { return dive; } set { dive = value; } }


    public void OnPointerDown(PointerEventData eventData)
    {
        directPos = GetDirectPos(eventData.position);
        attack = false;
    }
    

    public void OnDrag(PointerEventData eventData)
    {
        directPos = GetDirectPos(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        directPos = Vector3.zero;
        if(dive== true)
        {
            attack = true;
            dive = false;
        }
        else
        {
            dive = true;
        }
    }

    private Vector3 GetDirectPos(Vector2 eventDataPos)
    {
        ray = Camera.main.ScreenPointToRay(eventDataPos);
        directPos = ray.GetPoint(Camera.main.transform.position.y);
        return directPos;
    }
}
