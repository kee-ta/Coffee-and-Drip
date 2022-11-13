using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : SingletonController<GameUIController>
{
    [SerializeField] ModalWindowPanel modalWindow;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        //modalWindow.ShowVertical("",sprite,"This is a test message!",null);
        modalWindow.ShowHorizontal("Title window text",sprite,"This is a test message!",null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
