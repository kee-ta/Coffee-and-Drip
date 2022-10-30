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
    [SerializeField] private Transform pivot;

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

    private IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(2);
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
                    StartCoroutine((WaitABit()));
                    foo = Instantiate(lightRoasts[0], new Vector3(transform.position.x + UnityEngine.Random.Range(1, 6),
                                                                  transform.position.x + UnityEngine.Random.Range(1, 6),
                                                                  transform.position.z), transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.LIGHT;
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(1f, 1f), ForceMode2D.Impulse);
                }
                break;
            case RoastLevel.MEDIUM:
                for (int x = 0; x < 3; x++)
                {
                    StartCoroutine((WaitABit()));
                    foo = Instantiate(mediumRoasts[0], new Vector3(transform.position.x + UnityEngine.Random.Range(1, 6),
                                                                  transform.position.x + UnityEngine.Random.Range(1, 6),
                                                                  transform.position.z), transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.MEDIUM;
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(1f, 1f), ForceMode2D.Impulse);
                }
                break;
            case RoastLevel.DARK:
                for (int x = 0; x < 3; x++)
                {
                    StartCoroutine((WaitABit()));
                    foo = Instantiate(darkRoasts[0], new Vector3(transform.position.x + UnityEngine.Random.Range(1, 6),
                                                                  transform.position.x + UnityEngine.Random.Range(1, 6),
                                                                  transform.position.z), transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.DARK;
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(1f, 1f), ForceMode2D.Impulse);
                }
                break;
            default:
                //Do Nothing
                break;
        }
        ResetRoaster();
    }

    private void ResetRoaster()
    {
        tracker.GetComponent<RoastZoneRotate>().Reset();
        StartCoroutine(RotatePivot());
        rawBeans = null;
        loaded = false;
        fire.Stop();
    }

    private IEnumerator RotatePivot()
    {

            yield return null;
        
    }

}
