using System.Collections;
using System.Collections.Generic;

public class GreenBeanData : Ingredient, IRoastable
{
    public RoastModifier light;
    public RoastModifier medium;
    public RoastModifier dark;
    public RoastModifier darkThenBlack;

    public GreenBeanData(){
        this.light = new RoastModifier();
        this.medium = new RoastModifier();
        this.dark = new RoastModifier();
        this.darkThenBlack = new RoastModifier();
    }
    
    public GreenBeanData(RoastModifier light, RoastModifier medium, RoastModifier dark, RoastModifier darkThenBlack)
    {
        this.light = light;
        this.medium = medium;
        this.dark = dark;
        this.darkThenBlack = darkThenBlack;
    }
}
