using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AmbientSoundManager : MonoBehaviour
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
	void PlayRain(){
		AudioManager.instance.PlayAmbient(ambientRain, 5);
	}
    void StopSound(){
        AudioManager.instance.StopAmbient();
    }
    void PlayWind()
    {
     	AudioManager.instance.PlayAmbient(ambientWind, 5);
    }
    void PlayForest()
    {
     	AudioManager.instance.PlayAmbient(ambientForest, 5);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
