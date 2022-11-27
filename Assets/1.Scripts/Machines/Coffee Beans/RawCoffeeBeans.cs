using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawCoffeeBeans : MonoBehaviour
{
    public GreenBeanData rawStats = new GreenBeanData();
    private string beanName;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = AssetManager.I.rawBeans;
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }

    public string GetName(){
        return beanName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
