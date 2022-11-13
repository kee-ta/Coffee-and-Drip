using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ModalWindowPanel : MonoBehaviour
{
    [Header("Window")]
    [SerializeField] RectTransform modalWindow;
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
        CloseWindow();
    }
    public void Deny()
    {
        onDeny?.Invoke();
        CloseWindow();
    }
    public void Alternate()
    {
        onAlternate?.Invoke();
        CloseWindow();
    }

    public void ShowVertical(string title, Sprite image, string message, Action confirmAction)
    {
        horizontalLayoutArea.gameObject.SetActive(false);
        verticalLayoutArea.gameObject.SetActive(true);

        if (!string.IsNullOrEmpty(title))
        {
            headerArea.gameObject.SetActive(true);
        }
        else
        {
            headerArea.gameObject.SetActive(false);
        }

        titleTxt.text = title;

        verticalImage.gameObject.SetActive(true);
        verticalImage.sprite = image;
        verticalCaptionText.text = message;

        onConfirm = confirmAction;
        OpenWindow();
    }
    public void ShowHorizontal(string title, Sprite image, string message, Action confirmAction)
    {
        verticalLayoutArea.gameObject.SetActive(false);
        horizontalLayoutArea.gameObject.SetActive(true);

        if (!string.IsNullOrEmpty(title))
        {
            headerArea.gameObject.SetActive(true);
        }
        else
        {
            headerArea.gameObject.SetActive(false);
        }

        titleTxt.text = title;



        horizontalImage.gameObject.SetActive(true);
        horizontalImage.sprite = image;
        horizontalCaptionText.text = message;

        onConfirm = confirmAction;
        OpenWindow();
    }

    public void ShowNoImage(string title, string message, Action confirmAction)
    {
        horizontalLayoutArea.gameObject.SetActive(false);

        if (!string.IsNullOrEmpty(title))
        {
            headerArea.gameObject.SetActive(true);
        }
        else
        {
            headerArea.gameObject.SetActive(false);
        }

        titleTxt.text = title;


        verticalCaptionText.text = message;

        onConfirm = confirmAction;
        OpenWindow();
    }
    public void OpenWindow()
    {
        LeanTween.scale(modalWindow, modalWindow.localScale * 0f, 0f);
        LeanTween.scale(modalWindow, modalWindow.localScale * 1f, .3f).setDelay(0.03f);
    }
    public void CloseWindow()
    {
        LeanTween.scale(modalWindow, modalWindow.localScale * 0f, .1f);
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
