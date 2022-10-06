using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static Action newGame, continueGame;

    [Header ("Menu Buttons")]
    [SerializeField] private Button newGameButton, continueGameButton;
    public void NewGameClick()
    {
        newGame?.Invoke();
    }
    
    public void ContinueGameClick () 
    {
        continueGame?.Invoke();
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
