using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCoffeeBeans : MonoBehaviour
{
    GroundCoffeeData grind = new GroundCoffeeData();

    private string beanName;
    // Start is called before the first frame update
    void Start()
    {
        this.grind.sweetness = 0; this.grind.acidity = 0; this.grind.aroma = 0;
        beanName = "Ground Magic Bean";
    }

    public void SetStats(int sweetness, int acidity, int aroma)
    {
        this.grind.sweetness = sweetness;
        this.grind.acidity = acidity;
        this.grind.aroma = aroma;
    }  

    
    public void SetStats(int sweetness, int acidity, int aroma, Flavor flavor)
    {
        this.grind.sweetness = sweetness;
        this.grind.acidity = acidity;
        this.grind.aroma = aroma;
        this.grind.flavor = flavor;
    }    

    public void SetName(string name)
    {
        this.beanName = name;
    }

    public string GetName(){
        return beanName;
    }
}
