using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

public class God : SingletonController<God>
{
    [Header("List of Scenes")]
    [SerializeField] public List<SceneAsset> allScenes = new List<SceneAsset>();

    public List<Quest> allQuests;

    public void GiveQuest()
    {
        List<QuestCondition> temp = new List<QuestCondition>();
        temp.Add(new QuestCondition(QuestType.AROMA, 2));
        temp.Add(new QuestCondition(QuestType.ACID, 5));
        allQuests.Add(new Quest(1, "testQuest", "desc", temp));
        PlayerController.I.currentQuest = allQuests[0];
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
    }
    private void Update()
    {

    }
}
