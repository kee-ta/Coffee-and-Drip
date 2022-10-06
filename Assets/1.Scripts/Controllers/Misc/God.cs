using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

public class God : SingletonController<God>
{
    [Header ("List of Scenes")]
    [SerializeField] public List<SceneAsset> allScenes = new List<SceneAsset>();

    private void OnEnable() 
    {

    }
    private void OnDisable() 
    {

    }

    private void Start() 
    {

    }

}
