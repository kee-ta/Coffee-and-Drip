using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    private RectTransform trans;
    private TextMeshProUGUI text;

    private Vector3 readyPos = new Vector3(20, 220, 0);
    private Vector3 shownPos = new Vector3(20, -10, 0);
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<RectTransform>();
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //Refresh();
    }

    public void SetText(string x)
    {
        text.text = x;
    }

    private IEnumerator AnimateIn()
    {
        float time = 0;
        while (trans.anchoredPosition3D != shownPos)
        {
            trans.anchoredPosition3D = Vector3.Lerp(readyPos, shownPos, time * 2);
            time += Time.deltaTime;
            yield return null;
        }

    }

    private IEnumerator AnimateOutThenIn()
    {
        trans.anchoredPosition3D = shownPos;
        float time = 0;
        while (trans.anchoredPosition3D != readyPos)
        {
            trans.anchoredPosition3D = Vector3.Lerp(shownPos, readyPos, time * 1.5f);
            time += Time.deltaTime;
            yield return null;
        }
         yield return StartCoroutine(AnimateIn()); 
    }

    private IEnumerator AnimateOut()
    {
        float time = 0;
        while (trans.anchoredPosition3D != readyPos)
        {
            trans.anchoredPosition3D = Vector3.Lerp(shownPos, readyPos, time * 2);
            time += Time.deltaTime;
            yield return null;
        }

    }
    public void Refresh()
    {
        text.text = PlayerController.I.currentQuest.description;
        Debug.Log(PlayerController.I.currentQuest.description + " From QD");
        StartCoroutine(AnimateOutThenIn());
    }
    public void Display()
    {
        StartCoroutine(AnimateIn());
    }

    public void Reset()
    {
        StartCoroutine(AnimateOut());
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Refresh();
        }
    }
}
