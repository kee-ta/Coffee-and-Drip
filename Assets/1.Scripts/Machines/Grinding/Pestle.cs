using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Pestle : MonoBehaviour
{
    private Vector3 _dragOffset;
    public Rigidbody2D rb;
    public bool isHeld = false; 
    //bool canMove = true;
    LinkedList<Vector3> positions = new LinkedList<Vector3>();
    [SerializeField] private float _speed = 15;
    [SerializeField] ParticleSystem system;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        positions.AddLast(transform.position);
        if(positions.Count > 3)
        positions.RemoveFirst();

        var currentPosition = transform.position;
        if(((currentPosition.y-positions.Last.Value.y > 0.01)) || (positions.Last.Value.y-currentPosition.y > 0.01))
        {
            //Debug.Log("Hello!");
            //Do something
        }
    

    }

    void FixedUpdate()
    {
        
    }
    void OnMouseDown() 
    {
        //Debug.Log("Grabbed!");
        isHeld= true;

        if(rb.rotation!= 0)
        rb.rotation = 0f;

        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        rb.isKinematic = true;
        _dragOffset = transform.position - GetMousePos();
        //system.Play();
    }

    void OnMouseDrag() { 
        if(rb.rotation!= 0)
        rb.rotation = 0f;
        if((Math.Abs(positions.Last.Value.y) - Math.Abs(transform.position.y)<0.001) || (Math.Abs(transform.position.y) - Math.Abs(positions.Last.Value.y)<0.001) )
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        if((Math.Abs(positions.Last.Value.x) - Math.Abs(transform.position.x)<0.001) || (Math.Abs(transform.position.x) - Math.Abs(positions.Last.Value.x)<0.001) )
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        
    }

    void OnMouseUp(){
        isHeld=false;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.isKinematic = false;
        rb.velocity = new Vector2(0.0f, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        system.Play();
    }

    Vector3 GetMousePos() {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
