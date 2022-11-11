using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OneOfTutorial : MonoBehaviour
{
    public GameObject d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            d.SetActive(false);
        }
    }

    public void Go () {
        AudioManager.instance.PlaySound2D("buttonPress");
        SceneManager.LoadScene("Tutorial",LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Pretutorial");
    }
}
