using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawCoffeeBeans : MonoBehaviour
{
    GreenBeanData rawStats = new GreenBeanData();
    private string beanName;

    private int sweetness, acidity, aroma;


    public RawCoffeeBeans(string beanName , GreenBeanData stats){
        this.beanName = beanName;
        rawStats = stats;

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
