using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoastZoneRotate : MonoBehaviour
{
    private float RotateSpeed = 3f;
    [SerializeField]
    private float Radius = 1.2f;
    private Vector2 _centre;
    private float _angle;
    private float timer = 0.0f;
    private float waitTime = .6f;
    private bool started = false;

    public static Action roastTick;

    private void DirectionChange()
    {
       RotateSpeed = UnityEngine.Random.Range(-1f,1f);
    }

    private void StartTurning()
    {
        started = true;
    }

    private void StopTurning()
    {
        started = false;
    }
    
    private void OnEnable() 
    {
        RoastingController.RoastingStarted += StartTurning;
    }

    private void OnDisable() 
    {
        RoastingController.RoastingStarted -= StartTurning;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (timer > waitTime)
        {
            timer = timer - waitTime;
            roastTick?.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DirectionChange", 2.0f, 3f);
        _centre = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(started){
        timer += Time.deltaTime;
        _angle += RotateSpeed * Time.deltaTime;
 
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
        }
    }
}
