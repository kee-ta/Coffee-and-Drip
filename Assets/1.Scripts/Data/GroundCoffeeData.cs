using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GroundCoffeeData : Ingredient, IBrewable
{
    public string itemId;
    public RoastLevel roast;
    public GroundCoffeeData(){
        this.roast = RoastLevel.NULL;
        this.acidity=0;
        this.aroma=0;
        this.sweetness=0;
        this.flavor = Flavor.NONE;
        this.itemId = "000";
    }
}
