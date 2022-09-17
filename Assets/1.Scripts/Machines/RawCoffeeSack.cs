using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RawCoffeeSack : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    string sackName;
    [SerializeField]
    int sackID;

    public RawCoffeeSack()
    {
        this.sackName = "A magic sack!";
        sackID = 000;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(){
        Instantiate(prefab);
        Debug.Log("Spawning!");
    }

    public void SpawnRandom(){
        //Instantiate();
    }

    private void OnMouseUp() {
        Spawn();
    }
}
