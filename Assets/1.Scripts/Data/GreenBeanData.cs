using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class GreenBeanData : Ingredient, IRoastable
{
    public RoastModifier light;
    public RoastModifier medium;
    public RoastModifier dark;

    public GreenBeanData(){
        this.light = new RoastModifier();
        this.medium = new RoastModifier();
        this.dark = new RoastModifier();
    }
    
    public GreenBeanData(RoastModifier light, RoastModifier medium, RoastModifier dark)
    {
        this.light = light;
        this.medium = medium;
        this.dark = dark;
    }
}
