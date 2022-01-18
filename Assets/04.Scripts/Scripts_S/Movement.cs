using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Variable
    private Vector2 startPoint;
    private Vector2 moveDirect;
    // Property 
    [HideInInspector]
    public Vector2 MoveDirect { get { return moveDirect; } }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveDirect = eventData.position - startPoint;
        moveDirect = moveDirect.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startPoint = Vector2.zero;
        moveDirect = Vector2.zero;
    }
}
