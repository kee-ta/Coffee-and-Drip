using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Roaster : MonoBehaviour
{
    public RawCoffeeBeans loadedBeans;
    public static Action startRoastingGame;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.GetComponent<RawCoffeeBeans>())
        {
            loadedBeans = other.gameObject.GetComponent<RawCoffeeBeans>();
            Destroy(other.gameObject);
            Debug.Log(loadedBeans.GetName());
            startRoastingGame?.Invoke();
        }
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
