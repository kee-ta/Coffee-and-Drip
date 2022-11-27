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

    GreenBeanData loadedData;
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
            AudioManager.instance.PlaySound2D("beanDrop");
            fire.Play();
            AudioManager.instance.PlaySound2D("roasterStart");
            tracker.SetActive(true);
            startRoastingGame?.Invoke();
            AmbientSoundManager.I.PlayWind();
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
                for (int x = 0; x < 1; x++)
                {
                    StartCoroutine((WaitABit()));
                    foo = Instantiate(lightRoasts[0], new Vector3(transform.position.x + UnityEngine.Random.Range(2, 3),
                                                                  transform.position.y + UnityEngine.Random.Range(2, 3),
                                                                  transform.position.z), transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    
                    temp.roastLevel = RoastLevel.LIGHT;
                    temp.acidity = rawBeans.rawStats.acidity+rawBeans.rawStats.light.acidMod;
                    temp.sweetness = rawBeans.rawStats.sweetness+rawBeans.rawStats.light.sweetMod;
                    temp.aroma = rawBeans.rawStats.aroma+rawBeans.rawStats.light.aromaMod;
                    temp.ingredientID = rawBeans.rawStats.ingredientID+ 100;
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
                }
                break;
            case RoastLevel.MEDIUM:
                for (int x = 0; x < 1; x++)
                {
                    StartCoroutine((WaitABit()));
                    foo = Instantiate(mediumRoasts[0], new Vector3(transform.position.x + UnityEngine.Random.Range(2, 3),
                                                                  transform.position.y + UnityEngine.Random.Range(2, 3),
                                                                  transform.position.z), transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.MEDIUM;
                    temp.acidity = rawBeans.rawStats.acidity+rawBeans.rawStats.medium.acidMod;
                    temp.sweetness = rawBeans.rawStats.sweetness+rawBeans.rawStats.medium.sweetMod;
                    temp.aroma = rawBeans.rawStats.aroma+rawBeans.rawStats.medium.aromaMod;
                    temp.ingredientID = rawBeans.rawStats.ingredientID+ 200;
                    Debug.Log("Mods are:" +rawBeans.rawStats.medium.acidMod.ToString() + "/"
                                            +rawBeans.rawStats.medium.sweetMod.ToString()+ "/"
                                            +rawBeans.rawStats.medium.aromaMod.ToString());
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
                }
                break;
            case RoastLevel.DARK:
                for (int x = 0; x < 1; x++)
                {
                    StartCoroutine((WaitABit()));
                    foo = Instantiate(darkRoasts[0], new Vector3(transform.position.x + UnityEngine.Random.Range(2, 3),
                                                                  transform.position.y + UnityEngine.Random.Range(2, 3),
                                                                  transform.position.z), transform.rotation).gameObject;
                    temp = foo.GetComponent<RoastedCoffeeBeans>().roast;
                    temp.roastLevel = RoastLevel.DARK;
                    temp.acidity = rawBeans.rawStats.acidity+rawBeans.rawStats.dark.acidMod;
                    temp.sweetness = rawBeans.rawStats.sweetness+rawBeans.rawStats.dark.sweetMod;
                    temp.aroma = rawBeans.rawStats.aroma+rawBeans.rawStats.dark.aromaMod;
                    temp.ingredientID = rawBeans.rawStats.ingredientID+ 300;
                    rb = foo.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
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
        AmbientSoundManager.I.StopSound();
    }

    private IEnumerator RotatePivot()
    {

            yield return null;
        
    }

}
