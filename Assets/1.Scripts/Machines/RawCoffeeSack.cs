using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RawCoffeeSack : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    string sackName;
    [SerializeField]
    int sackID;
    [SerializeField]
    public Transform targetPos;
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

    public void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        Debug.Log("Spawning!");
    }

    public void SpawnRandom()
    {
        //Instantiate();
    }

    public void OnPointerDown(PointerEventData data)
    {
        Spawn();
    }

    private void OnMouseUp()
    {
        Spawn();
    }
}
