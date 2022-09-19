using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    public static Action propFiddled;
    private float startPosX, startPosY;
    private bool isBeingHeld;
    Vector2 oldPos, lowSens = new Vector2(.5f,.5f);
    Vector2 mousePos;

    void Start()
    {
        isBeingHeld = false;
    }

    void Update()
    {
        if (isBeingHeld == true)
        {
            // get the current position
            Vector3 newPosition = transform.position;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //position of object is set to center of object minus the difference in position
            gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }


    private void OnMouseDown()
    {

            Debug.Log("Props dragged");

            oldPos = transform.position;

            //set value to position of mouse in entire screen, then in game screen
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //difference between the current mouse position on the object and the center of the object
            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;

            isBeingHeld = true;

            Vector2 limit = new Vector2(transform.position.x + 1, transform.position.y + 1);
            if (mousePos == limit)
            {
                isBeingHeld = false;
            }
            
        
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
        propFiddled?.Invoke();
        //if there are no yokais behind the props, snap them back to their original position
        if (gameObject.tag != "Yokai Behind")
        {
            transform.position = oldPos;
        }
    }
}
