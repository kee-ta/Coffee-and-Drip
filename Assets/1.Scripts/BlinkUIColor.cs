using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class BlinkUIColor : MonoBehaviour
{
    public Color colorIni = Color.white;
    public Color colorFin = Color.red;
    public float duration = 3f;
    Color lerpedColor = Color.white;
 
    private float t = 0;
    private bool flag;
 
    Image _renderer;
     // Use this for initialization
    void Start()
    {
         _renderer = GetComponent<Image>();
    }
 
    void Update()
    {
        lerpedColor = Color.Lerp(colorIni, colorFin, t);
        _renderer.color = lerpedColor;
 
        if(flag == true)
        {
            t -= Time.deltaTime / duration;
            if (t < 0.01f)
                flag = false;
        }
         else
        {
            t += Time.deltaTime / duration;
            if (t > 0.99f)
                flag = true;
        }
    }
}

/*
 private IEnumerator ChangeColor(Image image, Color from, Color to, float duration)
     {
         float timeElapsed = 0.0f;
         
         float t = 0.0f;
         while(t < 1.0f)
         {
             timeElapsed += Time.deltaTime;
 
             t = timeElapsed / duration;
 
             image.color = Color.Lerp(from, to, t);
             
             yield return null;
         }
     }

      StartCoroutine(ChangeColor(image, Color.blue, Color.red, 3f));
*/
