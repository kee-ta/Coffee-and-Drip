using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BrewerUI : MonoBehaviour
{
    public Canvas brewCanvas;
    public Image brewSlot1, brewSlot2, brewSlot3;
    public Button brewStart;
    public GameObject brewMinigame;

    public static Action StartBrewing;

    private void OnEnable() 
    {
        Brewer.slotFilled += ShowSlot;
    }
    private void OnDisable() 
    {
        Brewer.slotFilled -= ShowSlot;
    }

    public void ShowSlot()
    {
        brewCanvas.gameObject.SetActive(true);
        if(brewSlot1.gameObject.activeInHierarchy == false)
        {
            brewSlot1.gameObject.SetActive(true);
        }
        else if(brewSlot2.gameObject.activeInHierarchy == false)
        {
            brewSlot2.gameObject.SetActive(true);
        }
        else if(brewSlot3.gameObject.activeInHierarchy == false)
        {
            brewSlot3.gameObject.SetActive(true);
            brewStart.gameObject.SetActive(true);
        }
        else{
            //do nothing
        }
    }

    public void ActivateBrewingGame() 
    {
        StartBrewing?.Invoke();
        brewMinigame.SetActive(true);
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
