using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle, tabActive, tabHover;
    public TabButton selectedTab;
    public List<GameObject> swapPages;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab != null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < swapPages.Count; i++) {
            if(i == index)
            {
                swapPages[i].SetActive(true);
            }
            else{
                swapPages[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton x in tabButtons)
        {
            if (selectedTab != null && x == selectedTab) { continue; }
            x.background.sprite = tabIdle;
        }
    }
}
