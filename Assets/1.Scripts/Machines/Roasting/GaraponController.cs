using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaraponController : MonoBehaviour
{
    [SerializeField] Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() 
    {
        if(pivot.GetComponent<Pivot>().canMove)
        transform.Rotate (0,0,10*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
