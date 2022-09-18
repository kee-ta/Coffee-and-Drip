using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class God : SingletonController<God>
{
    public GameObject roastingGame;

    private void OnEnable() 
    {
        Roaster.startRoastingGame += ActivateRoastingGame;
    }
    private void OnDisable() 
    {
        Roaster.startRoastingGame -= ActivateRoastingGame;
    }

    void ActivateRoastingGame()
    {
        roastingGame.SetActive(true);
    }

    void DeactivateRoastingGame()
    {
        roastingGame.SetActive(false);
    }
}
