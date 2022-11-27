using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Packer : MonoBehaviour
{
    [SerializeField] Button packBtn;

    [SerializeField] GameObject stage;
    [SerializeField] List<Slot> slots = new List<Slot>();
    [SerializeField] GameObject ready;

    private GameObject thingy;

    public bool loaded = false;

    public static Action<GroundCoffeeData> spawnSack;
    private void Start()
    {
        ready.SetActive(false);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<GroundedCoffeeBeans>())
            ActivateSlot(other.gameObject.GetComponent<GroundedCoffeeBeans>().grind.ingredientID);

    }
    private void ActivateSlot(int id)
    {
        Debug.Log("Id is" + id);
        slots.Find(x => x.groundCoffeeData.itemId == id.ToString()).gameObject.SetActive(true);
        StartCoroutine(DelayDeactive());
    }

    IEnumerator DelayDeactive(){
        yield return new WaitForSecondsRealtime(1);
        ready.SetActive(false);
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PackerColidded! ID IS" + other.gameObject.GetComponent<GroundedCoffeeBeans>().grind.ingredientID);
        if (!loaded)
        {
            if (other.gameObject.GetComponent<GroundedCoffeeBeans>())
            {
                ready.SetActive(true);
                thingy = other.gameObject;
                loaded = true;
                //                packBtn.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<GroundedCoffeeBeans>())
            ActivateSlot(other.gameObject.GetComponent<GroundedCoffeeBeans>().grind.ingredientID);
        Debug.Log("Id is" + other.gameObject.GetComponent<GroundedCoffeeBeans>().grind.ingredientID);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("PackerColidded!");
        if (!loaded)
        {
            if (other.gameObject.GetComponent<GroundedCoffeeBeans>())
            {
                ready.SetActive(true);
                thingy = other.gameObject;
                other.gameObject.GetComponent<Transform>().position = stage.transform.position;
                other.gameObject.GetComponent<Dragger>().canDrag = false;
                loaded = true;
                packBtn.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        ready.SetActive(false);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        ready.SetActive(false);
    }

    public void PackAndSpawn()
    {
        AudioManager.instance.PlaySound2D("buttonPress");
        Rigidbody2D rb;
        rb = thingy.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(10f, 10f), ForceMode2D.Impulse);
        spawnSack?.Invoke(thingy.GetComponent<GroundedCoffeeBeans>().grind);
        Destroy(thingy, 1.1f);
        packBtn.gameObject.SetActive(false);
        loaded = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
