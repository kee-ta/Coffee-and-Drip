using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Brewer : MonoBehaviour
{
    public static Action slotFilled;
    public static Action slotCleared;
    public Stack<GameObject> brewStack = new Stack<GameObject>();
    public Stack<GroundCoffeeData> dataStack = new Stack<GroundCoffeeData>();

    private Vector3 stagePos = new Vector3(18, -1, 0);
    public int maxBrewSlots = 3;

    private void OnEnable()
    {
        BrewingController.finishedBrewing += Reset;
    }

    private void OnDisable()
    {
        BrewingController.finishedBrewing -= Reset;
    }

    private void Reset()
    {
        brewStack.Clear();
        for (int i = 0; i < 3; i++)
        {
            slotCleared?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Brewer hit");
        if (other.gameObject.GetComponent<GroundedCoffeeBeans>())
        {
            Debug.Log("Is grounded coffee");
            if (brewStack.Count < maxBrewSlots)
            {
                Debug.Log("is not full");
                brewStack.Push(other.gameObject);
                Debug.Log(brewStack.Peek().GetComponent<GroundedCoffeeBeans>().grind.sweetness.ToString());
                other.gameObject.SetActive(false);
                other.gameObject.GetComponent<Transform>().position = stagePos;
                slotFilled?.Invoke();

                Debug.Log("Sweetness is" + other.gameObject.GetComponent<GroundedCoffeeBeans>().grind.sweetness.ToString());
            }
        }
    }

    private void OnMouseDown()
    {
        if (brewStack.Count > 0)
        {
            ClearSlot();
        }
    }

    public GameObject ClearSlot()
    {
        slotCleared?.Invoke();
        brewStack.Peek().gameObject.SetActive(true);
        brewStack.Peek().GetComponent<Rigidbody2D>().AddForce(new Vector2(0.2f, 6f), ForceMode2D.Impulse);
        return brewStack.Pop();
    }

}