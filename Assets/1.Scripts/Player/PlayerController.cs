using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonController<PlayerController>
{
    public Quest currentQuest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(currentQuest.name);
    }
}
