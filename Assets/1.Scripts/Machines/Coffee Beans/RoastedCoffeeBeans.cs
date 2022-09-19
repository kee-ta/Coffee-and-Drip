using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoastedCoffeeBeans : MonoBehaviour
{

    public RoastCoffeeData roast = new RoastCoffeeData();
    private string beanName;
    // Start is called before the first frame update
    void Start()
    {
        this.roast.sweetness = 0; this.roast.acidity = 0; this.roast.aroma = 0;
        beanName = "Roasted Magic Bean";
    }

    public void SetStats(int sweetness, int acidity, int aroma)
    {
        this.roast.sweetness = sweetness;
        this.roast.acidity = acidity;
        this.roast.aroma = aroma;
    }  

    
    public void SetStats(int sweetness, int acidity, int aroma, Flavor flavor)
    {
        this.roast.sweetness = sweetness;
        this.roast.acidity = acidity;
        this.roast.aroma = aroma;
        this.roast.flavor = flavor;
    }    

    public void SetName(string name)
    {
        this.beanName = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
