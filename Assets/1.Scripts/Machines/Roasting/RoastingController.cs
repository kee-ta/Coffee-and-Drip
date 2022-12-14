using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RoastingController : MonoBehaviour
{
    public static Action RoastingStarted;
    public static Action<RoastLevel> RoastingEnded;
    public RoastLevel currentRoastLevel;

    [SerializeField] Image gauge;
    [SerializeField] Image lightGauge, mediumGauge, darkGauge;
    [SerializeField] Button roast, end;
    [SerializeField] int progress= 0;
    private void OnEnable() 
    {
        RoastZoneRotate.roastTick +=AddProgress;
        Roaster.startRoastingGame +=StartGame;
    }

    private void OnDisable() 
    {
        RoastZoneRotate.roastTick -=AddProgress;
        Roaster.startRoastingGame -=StartGame;
        lightGauge.fillAmount = 0;
        mediumGauge.fillAmount = 0;
        darkGauge.fillAmount = 0;
        roast.gameObject.SetActive(true);
        end.gameObject.SetActive(false);
    }


    private void ResetGauge () 
    {
        lightGauge.fillAmount = 0;
        mediumGauge.fillAmount = 0;
        darkGauge.fillAmount = 0;
    }

    private void StartGame () 
    {
        gauge.gameObject.SetActive(true);
        roast.gameObject.SetActive(true);
    }

    private void EndGame () 
    {
        
        gauge.gameObject.SetActive(false);
        end.gameObject.SetActive(false);
    }

    public void AddProgress()
    {
        progress++;
        FillGauge();
    }
    public void FillGauge()
    {
        if(lightGauge.fillAmount<1.0f){
            lightGauge.fillAmount += 0.05f;
            currentRoastLevel = RoastLevel.LIGHT;
        }
        else if(mediumGauge.fillAmount <1.0f){
            mediumGauge.fillAmount += 0.08f;
            currentRoastLevel = RoastLevel.MEDIUM;
        }
        else if(darkGauge.fillAmount <1.0f){
            darkGauge.fillAmount += 0.08f;
            currentRoastLevel = RoastLevel.DARK;
        }
    }
    public void BeginRoasting()
    {
        AudioManager.instance.PlaySound2D("buttonPress");
        RoastingStarted?.Invoke();
        RoastingButtonSwitch();
    }

    public void EndedRoasting()
    {
        AudioManager.instance.PlaySound2D("buttonPress");
        RoastingEnded?.Invoke(currentRoastLevel);
        RoastingButtonSwitch();
        ResetGauge();
        end.gameObject.SetActive(false);
        gauge.gameObject.SetActive(false);
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
