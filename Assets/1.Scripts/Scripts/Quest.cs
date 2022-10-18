using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int id;
    public List<QuestCondition> clearConditions = new List<QuestCondition>();
    public string name;
    public string description;

    public bool isCompleted= false;
    
    public Quest(int id, string name, string description, QuestCondition clearCondition)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.clearConditions.Add(clearCondition);
    }

    public Quest(int id, string name, string description, IEnumerable<QuestCondition> conditions)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        foreach(QuestCondition x in conditions)
        {
            clearConditions.Add(x);
        }
    }
}
