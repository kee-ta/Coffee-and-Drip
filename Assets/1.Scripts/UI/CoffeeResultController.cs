using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class CoffeeResultController : MonoBehaviour
{
    public RectTransform endcard;
    public Button doneButton;
    public GameObject holder;
    [SerializeField] TMPro.TMP_Text scoreText, acidText, sweetText, aromaText, bodyText;
    [SerializeField] Canvas scoreCanvas;
    [Header("Target Positions")]
    [SerializeField] List<GameObject> sweetTargetPos = new List<GameObject>();
    [SerializeField] List<GameObject> acidTargetPos = new List<GameObject>();
    [SerializeField] List<GameObject> aromaTargetPos = new List<GameObject>();
    [SerializeField] List<GameObject> bodyTargetPos = new List<GameObject>();
    [Header("Stars")]
    [SerializeField] List<Image> sweetList = new List<Image>();
    [SerializeField] List<Image> acidList = new List<Image>();
    [SerializeField] List<Image> aromaList = new List<Image>();
    [SerializeField] List<Image> bodyList = new List<Image>();
    [SerializeField] Brewer brewer;
    [SerializeField] BrewingController brewingController;

    int Score = 0;
    int sweetScore = 0, acidScore = 0, aromaScore = 0, bodyScore = 0;



    public void GetBrewerInfo()
    {
        List<GameObject> temp = new List<GameObject>();
        temp = brewer.brewStack.ToList<GameObject>();
        foreach (GameObject x in temp)
        {
            sweetScore += x.GetComponent<GroundedCoffeeBeans>().grind.sweetness;
            acidScore += x.GetComponent<GroundedCoffeeBeans>().grind.acidity;
            aromaScore += x.GetComponent<GroundedCoffeeBeans>().grind.aroma;
        }
        bodyScore = brewingController.bodyScore + 50;

        Score = bodyScore + sweetScore + acidScore + aromaScore;
    }


    // Start is called before the first frame update
    void Start()
    {
        /*
        sweetList.Add(stars);
        scoreCanvas.gameObject.SetActive(true);
        foreach(Image x in sweetList)
        {
            Instantiate(x);
            x.transform.SetParent(scoreCanvas.transform,false);
        }
        */
    }

    private void OnEnable()
    {
        BrewingController.finishedBrewing += GetBrewerInfo;
        BrewingController.finishedBrewing += ShowCanvas;
    }

    private void OnDisable()
    {
        BrewingController.finishedBrewing -= GetBrewerInfo;
        BrewingController.finishedBrewing -= ShowCanvas;
    }
    void SetScore(float value)
    {
        scoreText.text = value.ToString("0");
    }
    void SetSweetness(float value)
    {
        sweetText.text = value.ToString("0");
    }
    void SetAcid(float value)
    {
        acidText.text = value.ToString("0");
    }
    void SetAroma(float value)
    {
        aromaText.text = value.ToString("0");
    }
    void SetBody(float value)
    {
        bodyText.text = value.ToString("0");
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame()
    {
        /*
        endcard.gameObject.SetActive(true);
        LeanTween.alpha(endcard, 1.0f, 2.4f).setDelay(2f);
        Invoke("QuitGame", 7f);
        */
    }

    public void ToDialogue () {
        AudioManager.instance.PlaySound2D("buttonPress");
        SceneManager.UnloadSceneAsync("Tutorial");
        SceneManager.LoadScene("Dialogue",LoadSceneMode.Additive);
        StartCoroutine(hack());
        
    }

    private IEnumerator hack()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Dialogue"));
    }
    void QuitGame() { Application.Quit(); }
    void ShowCanvas()
    {
        scoreCanvas.gameObject.SetActive(true);
        //LeanTween.move(holder, new Vector3(1002, 547, 0), 0.5f);
        LeanTween.value(gameObject, 00, Score, 6f).setOnUpdate(SetScore);
        LeanTween.value(gameObject, 00, sweetScore, 4f).setOnUpdate(SetSweetness);
        LeanTween.value(gameObject, 00, aromaScore, 3f).setOnUpdate(SetAroma);
        LeanTween.value(gameObject, 00, acidScore, 1f).setOnUpdate(SetAcid);
        LeanTween.value(gameObject, 00, bodyScore, 2f).setOnUpdate(SetBody);
    }
}
