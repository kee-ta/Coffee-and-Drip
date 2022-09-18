using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RoastingController : MonoBehaviour
{
    public static Action RoastingStarted;

    [SerializeField] Image lightGauge, mediumGauge, darkGauge;
    [SerializeField] Button roast, end;
    [SerializeField] int progress= 0;
    private void OnEnable() 
    {
        RoastZoneRotate.roastTick +=AddProgress;
    }

    private void OnDisable() 
    {
        RoastZoneRotate.roastTick -=AddProgress;
        progress = 0;
    }
    public void AddProgress()
    {
        progress++;
        FillGauge();
    }
    public void FillGauge()
    {
        if(lightGauge.fillAmount<1.0f){
            lightGauge.fillAmount += 0.08f;
        }
        else if(mediumGauge.fillAmount <1.0f){
            mediumGauge.fillAmount += 0.08f;
        }
        else if(darkGauge.fillAmount <1.0f){
            darkGauge.fillAmount += 0.08f;
        }
    }
    public void BeginRoasting()
    {
        RoastingStarted?.Invoke();
        RoastingButtonSwitch();
    }

    public void RoastingButtonSwitch()
    {
        if(roast.enabled == true){
            Debug.Log("Switching!");
            end.gameObject.SetActive(true);
            roast.gameObject.SetActive(false);
        }
        else if(end.enabled == true)
        {
            Debug.Log("Switch again!");
            end.gameObject.SetActive(false);
            roast.gameObject.SetActive(true);
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
