using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private float minX, maxX;
        //minY, maxY;

    void OnMouseDrag()
    {
        Vector3 before_clamp = Camera.main.ScreenToWorldPoint(new Vector2(
            Input.mousePosition.x,
            Input.mousePosition.y));

        /*minX = before_clamp.x - 0.5f;
        maxX = before_clamp.x + 0.5f;
        minY = before_clamp.y;
        maxY = before_clamp.y + 0.25f;*/

       transform.position = new Vector2(
            Mathf.Clamp(before_clamp.x, minX, maxX),
            transform.position.y);

        //Mathf.Clamp(before_clamp.y, minY, maxY)
    }
}