using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pestle : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    public Rigidbody2D rb;
    public bool isHeld = false;

    [SerializeField] private float _speed = 10;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    void Update()
    {
    }
    void OnMouseDown() 
    {
        isHeld= true;
        //transform.Rotate(0,0,0);
        rb.velocity = new Vector2(0.0f, 2.0f);
        rb.angularVelocity = 0.0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        rb.isKinematic = true;
        _dragOffset = transform.position - GetMousePos();
    }

    void OnMouseDrag() { 
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    void OnMouseUp(){
        isHeld=false;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.isKinematic = false;
    }

    Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
