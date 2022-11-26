using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content;
    public string header;
    public bool isActive;

    public TooltipType type;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isActive)
        {
            if (type == TooltipType.DEFAULT)
            {
                TooltipSystem.Show(content, header);
                StartCoroutine("WaitABit");
            }
        }
    }
    private IEnumerator WaitABit()
    {
        yield return new WaitForSecondsRealtime(8);
        OnMouseExit();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }

    private void OnMouseEnter()
    {
        if (isActive)
        {
            switch (type)
            {
                case TooltipType.DEFAULT:
                    TooltipSystem.Show(content, header);
                    StartCoroutine("WaitABit");
                    break;
                default:

                    break;
            }
        }
    }
    private void OnMouseExit()
    {
        TooltipSystem.Hide();
    }
}
