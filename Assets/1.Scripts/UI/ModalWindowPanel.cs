using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ModalWindowPanel : MonoBehaviour
{
    [Header("Header")]
    [SerializeField] Transform headerArea;
    [SerializeField] TextMeshProUGUI titleTxt;
    [Header("Content")]
    [SerializeField] Transform contentArea, verticalLayoutArea;
    [SerializeField] Image verticalImage;
    [SerializeField] TextMeshProUGUI verticalCaptionText;
    [Space()]
    [SerializeField] Transform horizontalLayoutArea, horizontalImageContainer;
    [SerializeField] Image horizontalImage;
    [SerializeField] TextMeshProUGUI horizontalCaptionText;
    [Header("Footer")]
    [SerializeField] Transform footerArea;
    [SerializeField] Button confirmBtn, declineBtn, altBtn;

    public static Action onConfirm, onDeny, onAlternate;

    public void Confirm()
    {
        onConfirm?.Invoke();
    }
    public void Deny()
    {
        onDeny?.Invoke();
    }
    public void Alternate()
    {
        onAlternate?.Invoke();
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
