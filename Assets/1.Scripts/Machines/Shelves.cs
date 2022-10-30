using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shelves : MonoBehaviour
{

    [SerializeField] private List<GameObject> slots;
    private Slot slotData;
    int maxSlots = 3;

    private void OnEnable()
    {
        Packer.spawnSack += SpawnSack;
    }
    private void OnDisable()
    {
        Packer.spawnSack -= SpawnSack;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxSlots = slots.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnSack(GroundCoffeeData data)
    {
        var activeSlots = slots.Where(obj => obj.activeInHierarchy).ToList();
        foreach (GameObject x in slots)
        {
            if (data.itemId == x.GetComponent<Slot>().groundCoffeeData.itemId)
            {
                //return;
            }
            else
            {
                Debug.Log("Making a new one...");
                x.SetActive(true);
                x.GetComponent<Slot>().groundCoffeeData = data;
                return;
            }
        }
    }
}
