using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Roaster : Machine
{
    [SerializeField] private GameObject funnel;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject tracker;
    [SerializeField] public ParticleSystem fire;

    public static Action startRoastingGame;

    public bool loaded = false;

    public List<RoastedCoffeeBeans> lightRoasts = new List<RoastedCoffeeBeans>();
    public List<RoastedCoffeeBeans> mediumRoasts = new List<RoastedCoffeeBeans>();
    public List<RoastedCoffeeBeans> darkRoasts = new List<RoastedCoffeeBeans>();

    public RawCoffeeBeans rawBeans { get; set; }

    private Collider2D funnelCol;
    public RoasterBody roastBody;

    private void Start()
    {
        funnelCol = funnel.GetComponent<Collider2D>();
        roastBody = body.GetComponent<RoasterBody>();
    }

    private void StartRoasting()
    {
        if (loaded)
        {
            fire.Play();
            tracker.SetActive(true);
            startRoastingGame?.Invoke();
        }
    }

    public void SetLoadedRaw(RawCoffeeBeans input)
    {
        rawBeans = input;
    }

    private void OnEnable()
    {
        RoastingController.RoastingEnded += SpawnRoastedCoffee;
        RoastFunnel.funnelLoaded += StartRoasting;
    }

    private void OnDisable()
    {
        RoastingController.RoastingEnded -= SpawnRoastedCoffee;
        RoastFunnel.funnelLoaded -= StartRoasting;
    }

    private void SpawnRoastedCoffee(RoastLevel level)
    {
        tracker.gameObject.SetActive(false);
        GameObject foo;
        RoastCoffeeData temp;
        Rigidbody2D rb;
        switch (level)
        {
            case RoastLevel.LIGHT:
                for (int x = 0; x < 3; x++)
                {
                    foo = Instantiate(lightRoasts[0], transform.position, transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.LIGHT;
                    rb = lightRoasts[0].gameObject.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(0.5f, 0.5f), ForceMode2D.Impulse);
                }
                break;
            case RoastLevel.MEDIUM:
                for (int x = 0; x < 3; x++)
                {
                    foo = Instantiate(mediumRoasts[0], transform.position, transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.MEDIUM;
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(0.5f, 0.5f), ForceMode2D.Impulse);
                }
                break;
            case RoastLevel.DARK:
                for (int x = 0; x < 3; x++)
                {
                    foo = Instantiate(darkRoasts[0], transform.position, transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.DARK;
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(0.5f, 0.5f), ForceMode2D.Impulse);
                }
                break;
            default:
                //Do Nothing
                break;
        }

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
