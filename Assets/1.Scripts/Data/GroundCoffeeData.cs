using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GroundCoffeeData : Ingredient, IBrewable
{
    public string itemId;
    public RoastLevel roast;
    public GroundCoffeeData()
    {
        this.roast = RoastLevel.NULL;
        this.acidity = 0;
        this.aroma = 0;
        this.sweetness = 0;
        this.flavor = Flavor.NONE;
        this.itemId = "000";
    }

    public GroundCoffeeData(RoastLevel roast, int acidity, int aroma, int sweetness, Flavor flavor = Flavor.NONE)
    {
        this.roast = roast;
        this.acidity = acidity;
        this.aroma = aroma;
        this.sweetness = sweetness;
        this.flavor = flavor;
        this.itemId = "000";
    }
}
