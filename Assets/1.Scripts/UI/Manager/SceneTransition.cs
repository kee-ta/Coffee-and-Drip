using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
        /*
        StartCoroutine(AnimationHelper.FadeIn(panel, 1, 1.0f));
        StartCoroutine(AnimationHelper.FadeIn(scene, 1, 1.0f, 1.0f));
        StartCoroutine(AnimationHelper.FadeIn(caption, 1, 1.0f, 3.0f));
        */
        //SceneManager.UnloadSceneAsync("MainMenu", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
       // SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
    }

    private IEnumerator Hack()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
        StartCoroutine(HackMore());
        yield return null;
    }
    private IEnumerator HackMore()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Tutorial"));
    }

    public void ResetTransition()
    {
        scene.alpha = 0f;
        caption.alpha = 0f;
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.0f);
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
