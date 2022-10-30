using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private List<GroundedCoffeeBeans> beans;
    public GroundCoffeeData groundCoffeeData;

    private void OnMouseDown()
    {
        Spawn(((int)groundCoffeeData.roast)-1);
    }

    public void Spawn(int x){
        Instantiate(beans[x],transform.position,transform.rotation);
        Debug.Log("Spawning!");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
