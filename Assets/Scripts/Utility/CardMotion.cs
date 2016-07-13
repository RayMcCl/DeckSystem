using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class CardMotion : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Replace With Anchor Entity
    public RectTransform parent;
    //Replace Start Position with Hand Position
    Vector2 originPosition = Vector2.zero;
    Vector2 handPosition = Vector2.zero;
    public Vector2 targetPosition = Vector2.zero;
    float moveState = 0;

    //Rewrite Remaining Variables
    public bool moving = false;
    bool mouseDown = false;
    public float moveSpeed = 0.35f;

    //
    public void Update()
    {
        if (mouseDown)
            SetToMousePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (moving)
            MoveToTarget();
    }
    
    //
    void SetToMousePosition(Vector2 pos)
    {
        parent.position = pos;
    }

    //
    void MoveToTarget ()
    {
        moveState += moveSpeed * Time.deltaTime;
        parent.localPosition = Vector2.Lerp(originPosition, targetPosition, moveState);
        if ((Vector2)parent.localPosition == targetPosition)
        {
            moving = false;
            moveState = 0;
        }
    }

    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        originPosition = parent.localPosition;
        mouseDown = true;
    }

    //
    public void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;
        moving = true;
        targetPosition = handPosition;
        originPosition = parent.localPosition;
        //SetToMousePosition(startPos);
    }
    
    //
    public void SetTarget (Vector2 loc){
        originPosition = parent.localPosition;
        targetPosition = loc;
        moving = true;
    }

    //
    public void SetHandLocation (Vector2 loc)
    {
        handPosition = loc;
        originPosition = parent.localPosition;
        targetPosition = loc;
        moving = true;
    }
}
