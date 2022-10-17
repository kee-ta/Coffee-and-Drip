public enum RoastLevel
{
    LIGHT,
    MEDIUM,
    DARK
}

public enum QuestType
{
    NULL,
    SPECIAL,
    SWEET,
    ACID,
    AROMA,
    BODY,
    FLAVOR_BITTER,
    FLAVOR_BITTERSWEET,
    FLAVOR_FRUITY,
    FLAVOR_CHOCOLATE,
    FLAVOR_EARTHY,
    FLAVOR_NUTTY,
    FLAVOR_SOUR
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

public class QuestCondition
{
    public QuestType type;
    public int value;

    public QuestCondition(QuestType type, int value)
    {
        this.type = type;
        this.value = value;
    }
    public QuestType Type => type;
    public int Value => value;

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