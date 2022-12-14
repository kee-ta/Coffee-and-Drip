using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

public class God : SingletonController<God>
{
    [Header("List of Scenes")]
    //[SerializeField] public List<SceneAsset> allScenes = new List<SceneAsset>();

    public List<Quest> allQuests;
    public List<GreenBeanData> allRawBeans = new List<GreenBeanData>();

    public GameObject pauseCanvas;
    public void GiveQuest()
    {
        List<QuestCondition> temp = new List<QuestCondition>();
        temp.Add(new QuestCondition(QuestType.AROMA, 2));
        temp.Add(new QuestCondition(QuestType.ACID, 5));
        allQuests.Add(new Quest(1, "testQuest", "desc", temp));
        PlayerController.I.currentQuest = allQuests[0];
        //        Debug.Log(PlayerController.I.currentQuest.description);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void Start()
    {
        GiveQuest();
        allRawBeans.Add(new GreenBeanData());
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        //SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        StartCoroutine(Hack());
    }

    private IEnumerator Hack()
    {
        yield return null;


        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

        //asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.isDone)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
            }

            yield return null;
        }
    }

    private void OpenOrClose()
    {
        if (pauseCanvas.activeInHierarchy)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        if (pauseCanvas.activeInHierarchy)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void MuteUnMuteAudio()
    {
        if(AudioListener.pause)
       AudioListener.pause = false;
       else
       AudioListener.pause = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOrClose();
        }
    }
}
