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
    private float waitTime = .4f;
    public bool started = false;
    [SerializeField] public ParticleSystem trail;

    public static Action roastTick;

    private void DirectionChange()
    {
        RotateSpeed = UnityEngine.Random.Range(-1f, 1f);
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
        Reset();
    }

    public void Reset()
    {
        started = false;
        trail.Stop();
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pivot>())
        {
            if (timer > waitTime)
            {
                timer = timer - waitTime;
                roastTick?.Invoke();
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pivot>())
        {
            trail.Play();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pivot>())
        {
            trail.Stop();
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
        if (started)
        {
            timer += Time.deltaTime;
            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;
        }
    }
}
