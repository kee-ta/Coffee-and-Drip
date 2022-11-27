using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dragger : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    public Rigidbody2D rb;

    public ParticleSystem particles;

    public bool canDrag = true;
    public bool isHeld = false;
    bool canMove = true;
    LinkedList<Vector3> positions = new LinkedList<Vector3>();

    [SerializeField] private float _speed = 5;

    private void Start()
    {
        canMove = true;
        isHeld=true;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    private void Update()
    {
        positions.AddLast(transform.position);
        if (positions.Count > 3)
            positions.RemoveFirst();

        if (canMove)
        {
            rb.isKinematic = true;
            if ((Math.Abs(positions.Last.Value.y) - Math.Abs(transform.position.y) < 0.001) || (Math.Abs(transform.position.y) - Math.Abs(positions.Last.Value.y) < 0.001))
                transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
            if ((Math.Abs(positions.Last.Value.x) - Math.Abs(transform.position.x) < 0.001) || (Math.Abs(transform.position.x) - Math.Abs(positions.Last.Value.x) < 0.001))
                transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        isHeld = true;
        if (canDrag)
        {
            rb.velocity = new Vector2(0.0f, 2.0f);
            rb.angularVelocity = 0.0f;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            rb.isKinematic = true;
            _dragOffset = transform.position - GetMousePos();
        }
        particles.Play();
        canMove = false;
    }

    void OnMouseDrag()
    {
        if (canDrag)
        {
            if ((Math.Abs(positions.Last.Value.y) - Math.Abs(transform.position.y) < 0.001) || (Math.Abs(transform.position.y) - Math.Abs(positions.Last.Value.y) < 0.001))
                transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
            if ((Math.Abs(positions.Last.Value.x) - Math.Abs(transform.position.x) < 0.001) || (Math.Abs(transform.position.x) - Math.Abs(positions.Last.Value.x) < 0.001))
                transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        }
    }

    void OnMouseUp()
    {
        isHeld = false;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.isKinematic = false;
        canMove = false;
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
