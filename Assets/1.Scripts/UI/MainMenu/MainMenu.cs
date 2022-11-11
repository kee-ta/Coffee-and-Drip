using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static Action newGame, continueGame;

    [Header ("Menu Buttons")]
    [SerializeField] private Button newGameButton, continueGameButton;
    public void NewGameClick()
    {
        newGame?.Invoke();
        AudioManager.instance.PlaySound2D("buttonPress");
        SceneManager.LoadScene("Pretutorial",LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenu");
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
