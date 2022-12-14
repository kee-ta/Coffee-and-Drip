using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameUI : MonoBehaviour
{
    public Canvas canvas;
    public GameObject book;

    public static Action bookClosed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenOrClose () {
        AudioManager.instance.PlaySound2D("bookFlip");
        AudioManager.instance.PlaySound2D("buttonPress");
        if(book.activeInHierarchy)
        {
            book.SetActive(false);
        }
        else
        {
            book.SetActive(true);
        }
        bookClosed?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Tutorial"))
        {
            canvas.gameObject.SetActive(false);
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial"))
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
