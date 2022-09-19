using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Brewer : MonoBehaviour
{
    public static Action slotFilled;
    public Stack<GameObject> brew = new Stack<GameObject>();
    public int maxBrewSlots = 3;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Brewer hit");
        if(other.gameObject.GetComponent<GroundedCoffeeBeans>())
        {
            Debug.Log("Is grounded coffee");
            if(brew.Count<maxBrewSlots)
            {
            Debug.Log("is not full");
            brew.Push(other.gameObject);
            Destroy(other.gameObject);
            slotFilled?.Invoke();
            Debug.Log(brew.Peek().GetComponent<GroundedCoffeeBeans>().GetName());
            }
        }
    }

}