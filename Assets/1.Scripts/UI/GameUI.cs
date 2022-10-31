using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Canvas canvas;
    public GameObject book;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenOrClose () {
        if(book.activeInHierarchy)
        {
            book.SetActive(false);
        }
        else
        {
            book.SetActive(true);
        }
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
