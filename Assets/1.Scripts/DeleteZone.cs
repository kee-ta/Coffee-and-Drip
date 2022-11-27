using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<RoastedCoffeeBeans>() || other.gameObject.GetComponent<RawCoffeeBeans>() || other.gameObject.GetComponent<GroundedCoffeeBeans>())
        {
            if (!other.gameObject.GetComponent<Dragger>().isHeld)
            {
                Destroy(other.gameObject);
            }
        }
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
