using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BrewerUI : MonoBehaviour
{
    public Canvas brewCanvas;
    public List<Image> brewSlots;
    public Button brewStart;
    public GameObject brewMinigame;

    public static Action StartBrewing;

    private void OnEnable()
    {
        Brewer.slotFilled += ShowSlot;
        BrewingController.finishedBrewing += Reset;
        Brewer.slotCleared += HideSlot;
    }
    private void OnDisable()
    {
        Brewer.slotFilled -= ShowSlot;
        BrewingController.finishedBrewing -= Reset;
        Brewer.slotCleared += HideSlot;
    }

    private void Reset()
    {
        brewMinigame.SetActive(false);
    }

    public void HideSlot()
    {
        if (brewSlots[2].gameObject.activeInHierarchy)
        {
            brewSlots[2].gameObject.SetActive(false);
            brewStart.gameObject.SetActive(false);
        }
        else if (brewSlots[1].gameObject.activeInHierarchy)
        {
            brewSlots[1].gameObject.SetActive(false);
        }
        else if (brewSlots[0].gameObject.activeInHierarchy)
        {
            brewSlots[0].gameObject.SetActive(false);
        }
        else
        {
            //donothing
        }
    }

    public void ShowSlot()
    {
        if (!brewSlots[2].gameObject.activeInHierarchy)
        {
            brewSlots[2].gameObject.SetActive(true);
            
        }
        else if (!brewSlots[1].gameObject.activeInHierarchy)
        {
            brewSlots[1].gameObject.SetActive(true);
        }
        else if (!brewSlots[0].gameObject.activeInHierarchy)
        {
            brewSlots[0].gameObject.SetActive(true);
        }
        else
        {
            //donothing
        }
        if(brewSlots[0].gameObject.activeInHierarchy)
        {
            brewStart.gameObject.SetActive(true);
        }
    }

    public void ActivateBrewingGame()
    {
        brewMinigame.SetActive(true);
        StartBrewing?.Invoke();
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
