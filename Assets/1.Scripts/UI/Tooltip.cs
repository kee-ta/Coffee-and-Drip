using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI contentText;
    public LayoutElement layoutElement;

    public int wrapLimit;

    public RectTransform rectTrans;

    private void Awake(){
        rectTrans = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = ""){
        if(string.IsNullOrEmpty(header)){headerText.gameObject.SetActive(false);}
        else
        {
            headerText.gameObject.SetActive(true);
            headerText.text = header;
        }
        contentText.text = content;

        int headerLength = headerText.text.Length;
        int contentLength = contentText.text.Length;

        layoutElement.enabled = (headerLength > wrapLimit || contentLength > wrapLimit);
    }

    private void Update(){
        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.width;

        rectTrans.pivot = new Vector2(pivotX , pivotY);

        transform.position = position;


    }
    

}
