using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Roaster : Machine
{
    [SerializeField] private GameObject funnel;
    [SerializeField] private GameObject body;

    public bool loaded= false;
    
    public RawCoffeeBeans rawBeans{get;set;}

    private Collider2D funnelCol;
    public RoasterBody roastBody;

    private void Start()
    {
        funnelCol = funnel.GetComponent<Collider2D>();
        roastBody = body.GetComponent<RoasterBody>();
    }

    private void StartRoasting ()
    {
        if(roastBody.fire.isPlaying && loaded) 
        {
            
        }    
    }

    public void SetLoadedRaw (RawCoffeeBeans input) 
    {
        rawBeans = input;
    }

    #region Temp
    /*
    public RawCoffeeBeans loadedBeans;
    public static Action startRoastingGame;
    
    public List<RoastedCoffeeBeans> lightRoasts = new List<RoastedCoffeeBeans>();
    public List<RoastedCoffeeBeans> mediumRoasts = new List<RoastedCoffeeBeans>();
    public List<RoastedCoffeeBeans> darkRoasts = new List<RoastedCoffeeBeans>();
    
    private void OnCollisionEnter2D(Collision2D other) 
    {

    }
    private void OnEnable() 
    {
        RoastingController.RoastingEnded += SpawnRoastedCoffee;
    }

    private void OnDisable() 
    {
        RoastingController.RoastingEnded -= SpawnRoastedCoffee;
    }
    private void SpawnRoastedCoffee(RoastLevel level)
    {
        /*
        Rigidbody2D rb;
       switch (level) {
        case RoastLevel.LIGHT:
            Instantiate(lightRoasts[0],transform.position,transform.rotation);
            Instantiate(lightRoasts[0],transform.position,transform.rotation);
            Instantiate(lightRoasts[0],transform.position,transform.rotation);
            rb = lightRoasts[0].gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce( new Vector2(0.5f,0.5f),ForceMode2D.Impulse);
            break;
        case RoastLevel.MEDIUM:
            Instantiate(mediumRoasts[0],transform.position,transform.rotation);
            Instantiate(mediumRoasts[0],transform.position,transform.rotation);
            Instantiate(mediumRoasts[0],transform.position,transform.rotation);
            rb = mediumRoasts[0].gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce( new Vector2(0.5f,0.5f),ForceMode2D.Impulse);
            break;
        case RoastLevel.DARK:
            Instantiate(darkRoasts[0],transform.position,transform.rotation);
            Instantiate(darkRoasts[0],transform.position,transform.rotation);
            Instantiate(darkRoasts[0],transform.position,transform.rotation);
            rb = darkRoasts[0].gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce( new Vector2(0.5f,0.5f),ForceMode2D.Impulse);
            break;
        default :
            //Do Nothing
            break;
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
    
    */
    #endregion
}
