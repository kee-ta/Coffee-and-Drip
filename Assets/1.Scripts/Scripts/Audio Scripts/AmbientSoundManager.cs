using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AmbientSoundManager : SingletonController<AmbientSoundManager>
{
    public AudioClip ambientWind;
	public AudioClip ambientRain;
    public AudioClip ambientForest;
	void Start(){
		
	}

    void OnEnable(){
 
    }
    void OnDisable(){

    }
	public void PlayRain(){
		AudioManager.instance.PlayAmbient(ambientRain, 3);
	}
    public void StopSound(){
        AudioManager.instance.StopAmbient();
    }
    public void PlayWind()
    {
     	AudioManager.instance.PlayAmbient(ambientWind, 3);
    }
    public void PlayForest()
    {
     	AudioManager.instance.PlayAmbient(ambientForest, 3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
