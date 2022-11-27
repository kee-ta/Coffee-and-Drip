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
        if (other.gameObject.GetComponent<RawCoffeeBeans>() && !roaster.loaded)
        {
            GreenBeanData rawBeans = other.gameObject.GetComponent<RawCoffeeBeans>().rawStats;
            Debug.Log("Mods are:" + rawBeans.medium.acidMod.ToString() + "/"
                                           + rawBeans.medium.sweetMod.ToString() + "/"
                                           + rawBeans.medium.aromaMod.ToString());
            roaster.SetLoadedRaw(other.gameObject.GetComponent<RawCoffeeBeans>());
            Destroy(other.gameObject);
            roaster.loaded = true;
            funnelLoaded?.Invoke();
        }
    }
}
