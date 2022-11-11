using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelSystem : MonoBehaviour
{
    private static InfoPanelSystem current;
    public InfoPanel infoPanel;
    void OnEnable(){
    }
    void OnDisable(){
    }
    public void Awake()
    {
        current = this;
        Hide();
    }

    public static void Show(Ingredient id){
        current.infoPanel.SetInfo(id);
        current.infoPanel.gameObject.SetActive(true);
    }
    public static void Hide(){
        current.infoPanel.gameObject.SetActive(false);
    }

}
