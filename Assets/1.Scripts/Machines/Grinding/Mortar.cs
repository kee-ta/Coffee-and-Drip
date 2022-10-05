using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mortar : MonoBehaviour
{
    private SpriteRenderer spr;
    public static Action grinded;
    public static Action mounted;
    public bool loaded = false;
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();

    bool isColliding = false;

    public GroundedCoffeeBeans grinds;

    private int currentImage = 0;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.GetComponent<RoastedCoffeeBeans>())
        {
            Destroy(other.gameObject);
            currentImage++;
            spr.sprite = sprites[currentImage];
            mounted?.Invoke();
            loaded = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        
        if(other.gameObject.GetComponent<Pestle>() && loaded)
        {
            Debug.Log("Hit!!");
            if(currentImage<(sprites.Count-2))
            {
                currentImage++;
                spr.sprite = sprites[currentImage];
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(isColliding) return;
        isColliding = true;
        if(col.gameObject.GetComponent<Pestle>() && loaded)
        {
            Debug.Log("Hit!!");
            if(currentImage<(sprites.Count-2))
            {
                currentImage++;
                spr.sprite = sprites[currentImage];
            }
        }
        
    }
    void OnTriggerExit2D(Collider2D col){
        Debug.Log("exit!!");
        StartCoroutine(Reset());
    } 
    void OnMouseUp(){
        if(currentImage >= (sprites.Count-2))
        {
            spr.sprite = sprites[sprites.Count-1];
            Instantiate(grinds,transform.position,transform.rotation);
            currentImage = 0;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

     IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
