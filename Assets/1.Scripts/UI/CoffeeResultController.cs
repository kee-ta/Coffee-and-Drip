using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CoffeeResultController : MonoBehaviour
{
    public RectTransform endcard; 
    public Button doneButton;
    public GameObject holder;
    [SerializeField] TMPro.TMP_Text scoreText;
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
        BrewingController.finishedBrewing+=ShowCanvas;
    }

    private void OnDisable() 
    {
        BrewingController.finishedBrewing-=ShowCanvas;
    }
    void SetScore(float value){
        scoreText.text = value.ToString("0");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(){
        endcard.gameObject.SetActive(true);
        LeanTween.alpha(endcard,1.0f,2.4f).setDelay(2f);
        Invoke("QuitGame",7f);
    }

    void QuitGame(){Application.Quit();}
    void ShowCanvas()
    {
        scoreCanvas.gameObject.SetActive(true);
        LeanTween.move(holder,new Vector3(1002,547,0),0.5f);
        LeanTween.value(gameObject,00,17,1f).setOnUpdate(SetScore);
    }
}
