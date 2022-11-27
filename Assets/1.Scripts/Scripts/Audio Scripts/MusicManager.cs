using UnityEngine;
using System.Collections;
using System;

public class MusicManager : MonoBehaviour
{


    public AudioClip sceneTranquil;
    public AudioClip mainMenu;
    public AudioClip energy;
    public AudioClip Tranq2;
    bool stopRepeat = true;
    private int timesCalled = 0;
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
        Invoke("StartTranquil2", sceneTranquil.length + 17.0f);
    }
    public void StartTranquil2()
    {
        AudioManager.instance.PlayMusic(Tranq2, 0.5f);
        Invoke("StartEnergy", Tranq2.length + 20.0f);
    }
    public void StartEnergy()
    {
        AudioManager.instance.PlayMusic(energy, 0.5f);
        Invoke("StartTranquil", energy.length + 20.0f);
    }
    public void StartMainMenu()
    {
        AudioManager.instance.PlayMusic(mainMenu, 0.5f);
    }
    void Update()
    {

    }
}