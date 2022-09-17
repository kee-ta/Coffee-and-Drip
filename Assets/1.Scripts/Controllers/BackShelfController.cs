using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackShelfController : SingletonController<BackShelfController>
{
    [Header("Shelves")]
    [SerializeField] public List<Shelf> shelves = new List<Shelf>(); 
    [Header("Sacks")]
    [SerializeField] public List<RawCoffeeSack> sacks = new List<RawCoffeeSack>();

    void Start()
    {
        PlaceCoffeeSack();
    }
    public void PlaceCoffeeSack()
    {
        shelves[0].SpawnSack(sacks[0]);
        shelves[1].SpawnSack(sacks[0]);
    }
}
