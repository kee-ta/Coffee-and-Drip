public enum RoastLevel
{
    LIGHT,
    MEDIUM,
    DARK
}
public class RoastModifier
{
    public int sweetMod;
    public int acidMod;
    public int aromaMod;
    public Flavor flavorMod;

    public RoastModifier(){
        sweetMod = 0;
        acidMod = 0;
        aromaMod = 0;
        flavorMod = Flavor.NONE;
    }

    public RoastModifier(int sweetMod, int acidMod, int aromaMod, Flavor flavorMod){
        this.sweetMod = sweetMod;
        this.acidMod = acidMod;
        this.aromaMod = aromaMod;
        this.flavorMod = flavorMod;
    }
}
public enum Quality
{
    STALE,
    Common,
    Rare,
    Fancy
}
public enum Flavor
{
    BITTER,
    BITTERSWEET,
    FRUITY,
    CHOCOLATE,
    EARTHY,
    NUTTY,
    SOUR,
    NONE
}

public interface IRoastable{

}

public interface IGrindable{
    public void Grind(){}
}

public interface IBrewable{
    
}