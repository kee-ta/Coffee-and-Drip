using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData 
{
    public int count;
    public Dictionary<string,bool> eventFlags;

    public GameData()
    {
        this.count = 0;
        eventFlags = new Dictionary<string, bool>();
        eventFlags.Add("Day One", true);
        eventFlags.Add("Day Two", false);
    }
}
