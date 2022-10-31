using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private List<GroundedCoffeeBeans> beans;
    public GroundCoffeeData groundCoffeeData;

    [Header("Grind Settings")]
    public int acidity, aroma, sweetness;

    private void OnMouseDown()
    {
        Spawn(((int)groundCoffeeData.roast)-1);
    }

    public void Spawn(int x){
        groundCoffeeData.acidity = acidity;
        groundCoffeeData.aroma = aroma;
        groundCoffeeData.sweetness = sweetness;
        GroundedCoffeeBeans temp = Instantiate(beans[x],transform.position,transform.rotation);
        temp.grind = groundCoffeeData;
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
