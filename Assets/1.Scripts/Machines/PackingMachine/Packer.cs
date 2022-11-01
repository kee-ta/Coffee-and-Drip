using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Packer : MonoBehaviour
{   
    [SerializeField] Button packBtn;

    [SerializeField] GameObject stage;

    private GameObject thingy;

    public bool loaded= false;

    public static Action<GroundCoffeeData> spawnSack;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(!loaded)
        {
            if(other.gameObject.GetComponent<GroundedCoffeeBeans>())
            {
                thingy = other.gameObject;
                other.gameObject.GetComponent<Transform>().position = stage.transform.position;
                other.gameObject.GetComponent<Dragger>().canDrag = false;
                loaded = true;
                packBtn.gameObject.SetActive(true);
            }
        }
    }

    public void PackAndSpawn () 
    {
        AudioManager.instance.PlaySound2D("buttonPress");
        Rigidbody2D rb;
        rb = thingy.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(10f, 10f), ForceMode2D.Impulse);
        spawnSack?.Invoke(thingy.GetComponent<GroundedCoffeeBeans>().grind);
        Destroy(thingy,1.1f);
        packBtn.gameObject.SetActive(false);
        loaded = false;
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
