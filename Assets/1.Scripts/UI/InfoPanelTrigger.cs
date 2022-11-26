using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoPanelTrigger : MonoBehaviour
{
    public bool isActive;

    public TooltipType type;
    private Ingredient iD;


    private IEnumerator WaitABit()
    {
        yield return new WaitForSecondsRealtime(15);
        OnMouseExit();
    }


    private void OnMouseEnter()
    {
        if (isActive)
        {
            switch (type)
            {
                case TooltipType.GROUNDEDCOFFEE:
                iD = gameObject.GetComponent<GroundedCoffeeBeans>().grind;
                    break;
                case TooltipType.RAWCOFFEE:
                iD = gameObject.GetComponent<RawCoffeeBeans>().rawStats;
                    break;
                case TooltipType.ROASTCOFFEE:
                iD = gameObject.GetComponent<RoastedCoffeeBeans>().roast;
                    break;
                default:

                    break;
            }
            InfoPanelSystem.Show(iD);
            StartCoroutine("WaitABit");
        }
    }
    private void OnMouseExit()
    {
        InfoPanelSystem.Hide();
    }
}
