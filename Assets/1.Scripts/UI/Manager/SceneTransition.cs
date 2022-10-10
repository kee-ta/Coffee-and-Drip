using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    private CanvasGroup CanvasGroup;
    [SerializeField] TextMeshProUGUI scene, caption;
    [SerializeField] Image panel;

    void Awake()
    {
        CanvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.anyKeyDown){ResetTransition();}
    }

    public void BeginFadeIn()
    {
        StartCoroutine(AnimationHelper.FadeIn(panel, 1, 2.0f));
        StartCoroutine(AnimationHelper.FadeIn(scene, 1, 2.0f, 2.0f));
        StartCoroutine(AnimationHelper.FadeIn(caption, 1, 2.0f, 5.0f));
    }

    public void ResetTransition()
    {
        scene.alpha = 0f;
        caption.alpha = 0f;
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.0f);
    }

    private void OnEnable()
    {
        BeginFadeIn();
    }

    private void OnDisable()
    {
        ResetTransition();
    }


}
