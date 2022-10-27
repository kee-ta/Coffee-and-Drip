using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RoastFunnel : MonoBehaviour
{
    public static Action funnelLoaded;
    [SerializeField] private Roaster roaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.GetComponent<RawCoffeeBeans>() && !roaster.loaded)
        {
            roaster.SetLoadedRaw(other.gameObject.GetComponent<RawCoffeeBeans>());
            Destroy(other.gameObject);
            roaster.loaded = true;
            funnelLoaded?.Invoke();
        }
    }
}
