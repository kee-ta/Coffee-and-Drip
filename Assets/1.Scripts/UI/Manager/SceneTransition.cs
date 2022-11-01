using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] CanvasGroup CanvasGroup;
    [SerializeField] TextMeshProUGUI scene, caption;
    [SerializeField] Image panel;
    [SerializeField] Canvas canvas;


    void Awake()
    {
        
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
        canvas.gameObject.SetActive(true);
        StartCoroutine(AnimationHelper.FadeIn(panel, 1, .01f));
        StartCoroutine(AnimationHelper.FadeIn(scene, 1, 1.5f, 3.0f));
        StartCoroutine(FadeIn(caption, 1, 1.3f, 6.0f));
    }
    private IEnumerator FadeIn(TextMeshProUGUI text, float endValue, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
        float elapsedTime = 0;
        float startValue = text.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, newAlpha);
            yield return null;
        }
        yield return new WaitForSeconds(3);
        ResetTransition();
    }
    private IEnumerator Hack()
    {
        StartCoroutine(HackMore());
        yield return null;
    }
    private IEnumerator HackMore()
    {
        yield return new WaitForSecondsRealtime(1);
    }

    public void ResetTransition()
    {
        scene.alpha = 0f;
        caption.alpha = 0f;
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.0f);
        canvas.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        MainMenu.newGame += BeginFadeIn;
    }

    private void OnDisable()
    {
        MainMenu.newGame -= BeginFadeIn;
        ResetTransition();
    }


}
