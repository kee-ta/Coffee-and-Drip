using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawCoffeeBeans : MonoBehaviour
{
    public GreenBeanData rawStats = new GreenBeanData();
    private string beanName;

    private int sweetness, acidity, aroma;

    // Start is called before the first frame update
    void Start()
    {
        sweetness =0; acidity=0; aroma = 0;
        beanName = "Magic Bean";
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
