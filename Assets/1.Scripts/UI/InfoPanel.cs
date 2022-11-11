using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    public TextMeshProUGUI sweet,acid,aroma;
    public void SetInfo(Ingredient id)
    {
        sweet.text = id.sweetness.ToString();
        acid.text = id.acidity.ToString();
        aroma.text = id.aroma.ToString();

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
