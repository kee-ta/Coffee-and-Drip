using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject beanObject; 
    public GroundCoffeeData groundCoffeeData;

    GroundedCoffeeBeans beans { get; }

    private void OnMouseDown()
    {
        Spawn(0);
    }

    public void OnPointerDown(PointerEventData data)
    {
        Spawn(0);
    }
    public void Spawn(int x)
    {
        GroundedCoffeeBeans temp = Instantiate(beanObject, transform.position, transform.rotation).GetComponent<GroundedCoffeeBeans>();
        temp.grind.acidity = groundCoffeeData.acidity;
        temp.grind.aroma = groundCoffeeData.aroma;
        temp.grind.sweetness = groundCoffeeData.sweetness;
        temp.grind.itemId = groundCoffeeData.itemId;
        temp.grind.roast = groundCoffeeData.roast;
        Debug.Log("Spawn Ground");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
