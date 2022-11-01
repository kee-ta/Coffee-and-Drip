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


        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu",LoadSceneMode.Additive);

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
    private void Update()
    {

    }
}
