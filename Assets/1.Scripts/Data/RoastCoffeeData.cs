using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class RoastCoffeeData: Ingredient, IGrindable
{
    public RoastLevel roastLevel = RoastLevel.LIGHT;
    private int grindLevel= 5;

    public RoastCoffeeData()
    {
        this.acidity = 0;
        this.aroma = 0;
        this.sweetness = 0;
        this.flavor = Flavor.NONE;
    }
    
    public RoastCoffeeData(int sweetness, int acidity, int aroma, Flavor flavor)
    {
        this.sweetness = sweetness;
        this.acidity = acidity;
        this.aroma = aroma;
        this.flavor = flavor;
    }

    void Grind(){
        grindLevel--;
    }
}
