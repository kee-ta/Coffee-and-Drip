using System.Collections;
using System.Collections.Generic;

public class GroundCoffeeData : Ingredient, IBrewable
{
    public GroundCoffeeData(){
        this.acidity=0;
        this.aroma=0;
        this.sweetness=0;
        this.flavor = Flavor.NONE;
    }
}
