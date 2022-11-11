using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Image background;
    public TabGroup tabGroup;

    // Start is called before the first frame update
    void Start()
    {
        background = gameObject.GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
       tabGroup.OnTabSelected(this);
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
       tabGroup.OnTabEnter(this);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        
       tabGroup.OnTabExit(this);
    }    
}
