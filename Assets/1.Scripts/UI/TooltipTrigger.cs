using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content;
    public string header;
    public bool isActive;
    public void OnPointerEnter(PointerEventData eventData){
        if(isActive){
        TooltipSystem.Show(content,header);
        StartCoroutine("WaitABit");
        }
    }
    private IEnumerator WaitABit(){
        yield return new WaitForSecondsRealtime(5);
        OnMouseExit();
    }

    public void OnPointerExit(PointerEventData eventData){
        TooltipSystem.Hide();
    }

    private void OnMouseEnter(){
        if(isActive){
        TooltipSystem.Show(content,header);
         StartCoroutine("WaitABit");
        }
    }
    private void OnMouseExit(){
        TooltipSystem.Hide();
    }
}
