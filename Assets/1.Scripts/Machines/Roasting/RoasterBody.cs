using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoasterBody : MonoBehaviour
{
    [SerializeField] public ParticleSystem fire;
    private void OnMouseDown()
    {
        if (!fire.isPlaying)
            fire.Play();
        else
            fire.Stop();
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
