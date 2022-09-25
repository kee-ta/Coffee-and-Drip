using UnityEngine;
using System.Collections;
using System;

public class MusicManager : MonoBehaviour {


	public AudioClip sceneTranquil;
	bool stopRepeat= true;
	private int timesCalled;
	void OnEnable(){

	}
	void OnDisable(){

	}
	void Start(){
		StartTranquil();
	}
	public void StartTranquil()
    {
     	AudioManager.instance.PlayMusic(sceneTranquil,0.5f);
    }
	void Update(){
	
	}
}