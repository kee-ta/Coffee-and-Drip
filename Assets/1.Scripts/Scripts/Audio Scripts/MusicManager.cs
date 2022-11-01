using UnityEngine;
using System.Collections;
using System;

public class MusicManager : MonoBehaviour
{


    public AudioClip sceneTranquil;
    public AudioClip mainMenu;
    bool stopRepeat = true;
    private int timesCalled;
    void OnEnable()
    {
        MainMenu.newGame += StartTranquil;

    }
    void OnDisable()
    {
		MainMenu.newGame -= StartTranquil;
    }
    void Start()
    {
        StartMainMenu();
    }
    public void StartTranquil()
    {
        AudioManager.instance.PlayMusic(sceneTranquil, 0.5f);
    }
    public void StartMainMenu()
    {
        AudioManager.instance.PlayMusic(mainMenu, 0.5f);
    }
    void Update()
    {

    }
}