using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [SerializeField]
    public GameObject origin;

    private bool canMove = false;


    private void FixedUpdate() 
    {
        if(canMove)
        {
        Vector3 differnce = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        differnce.Normalize();
        float rotationZ = Mathf.Atan2(differnce.y,differnce.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
        }
    }

    private void OnMouseDown() 
    {
        canMove = true;
    }

    private void OnMouseUp() 
    {
        canMove = false;
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
