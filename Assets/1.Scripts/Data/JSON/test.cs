using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour, IDataPersistent
{
    public int dCount = 1;
    public void LoadData(GameData data){
        this.dCount = data.count;
    }
    public void SaveData(GameData data){
        data.count = dCount;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
