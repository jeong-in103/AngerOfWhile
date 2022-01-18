using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Variable
    private Vector3 directPos;
    // Property 
    [HideInInspector]
    public Vector3 DirectPos { get { return directPos; } }
    Ray ray;

    public void OnPointerDown(PointerEventData eventData)
    {
        directPos = GetDirectPos(eventData.position);
    }
    

    public void OnDrag(PointerEventData eventData)
    {
        directPos = GetDirectPos(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        directPos = Vector3.zero;
    }

    private Vector3 GetDirectPos(Vector2 eventDataPos)
    {
        ray = Camera.main.ScreenPointToRay(eventDataPos);
        directPos = ray.GetPoint(Camera.main.transform.position.y);
        return directPos;
    }
}
