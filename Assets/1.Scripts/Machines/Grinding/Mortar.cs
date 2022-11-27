using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mortar : MonoBehaviour
{
    public static Action grinded;
    public static Action mounted;
    public bool loaded = false;
    [SerializeField] List<Sprite> lightRoast = new List<Sprite>();
    [SerializeField] List<Sprite> medRoast = new List<Sprite>();
    [SerializeField] List<Sprite> darkRoast = new List<Sprite>();
    [SerializeField] List<GroundedCoffeeBeans> grounds = new List<GroundedCoffeeBeans>();
    [SerializeField] private SpriteRenderer frontMortar, backMortar;
    [SerializeField] public List<RoastedCoffeeBeans> roasts = new List<RoastedCoffeeBeans>();
    [SerializeField] private SpriteRenderer spr;

    private int hp = 0;
    private RoastLevel loadedType;
    RoastCoffeeData loadedBean;
    bool isColliding = false;

    private int currentImage = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isColliding) return;
        isColliding = true;
        if (col.gameObject.GetComponent<RoastedCoffeeBeans>() && !loaded)
        {
            loadedBean = col.gameObject.GetComponent<RoastedCoffeeBeans>().roast;
            AudioManager.instance.PlaySound2D("beanDrop");
            Destroy(col.gameObject);
            mounted?.Invoke();
            loaded = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            SetSprite(col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel);
            loadedType = col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel;
        }
        if (col.gameObject.GetComponent<Pestle>() && loaded)
        {
            if ((hp < 2))
            {
                AudioManager.instance.PlaySound2D("mortarHit");
                hp++;
                SetSprite(loadedType, hp);
            }
            if (hp >= 2)
            {

            }
        }
        FadeCover();
    }

    void SetSprite(RoastLevel level)
    {
        switch (level)
        {
            case RoastLevel.LIGHT:
                spr.sprite = lightRoast[0];
                break;
            case RoastLevel.MEDIUM:
                spr.sprite = medRoast[0];
                break;
            case RoastLevel.DARK:
                spr.sprite = darkRoast[0];
                break;
            default:

                break;
        }
    }

    private void OnMouseOver()
    {
        FadeCover();
    }

    private void OnMouseExit()
    {
        if (!loaded)
            FadeCover(false);
    }

    void SetSprite(RoastLevel level = RoastLevel.LIGHT, int stage = 0)
    {
        switch (level)
        {
            case RoastLevel.LIGHT:
                spr.sprite = lightRoast[stage];
                break;
            case RoastLevel.MEDIUM:
                spr.sprite = medRoast[stage];
                break;
            case RoastLevel.DARK:
                spr.sprite = darkRoast[stage];
                break;
            default:

                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log("exit!!");
        isColliding = false;
        StartCoroutine(Reset());
        if (!loaded)
        {
            FadeCover(false);
        }
    }
    void OnMouseUp()
    {
        if (!loaded)
            FadeCover(false);
    }

    private void FadeCover(bool doFade = true)
    {
        Color temp = frontMortar.color;

        if (doFade)
            temp.a = 0.3f;
        else
            temp.a = 1f;

        frontMortar.color = temp;
    }

    private void OnMouseDown()
    {
        FadeCover(true);
        if (loaded)
        {
            if (hp == 2)
                SpawnGrounded();
            else
            {
                SpawnRoasted();
            }
        }
        else
        {

        }
        ResetMortar();
    }

    private IEnumerator hack()
    {
        yield return new WaitForSecondsRealtime(3);
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    private void SpawnRoasted()
    {
        RoastCoffeeData foo;
        GameObject temp;
        Rigidbody2D rb;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        switch (loadedType)
        {
            case RoastLevel.LIGHT:
                temp = Instantiate(roasts[0], transform.position, transform.rotation).gameObject;
                temp.GetComponent<RoastCoffeeData>().roastLevel = RoastLevel.LIGHT;
                rb = temp.GetComponent<Rigidbody2D>();
                foo = temp.GetComponent<RoastedCoffeeBeans>().roast;
                foo.roastLevel = RoastLevel.LIGHT;
                foo.acidity = loadedBean.acidity;
                foo.sweetness = loadedBean.sweetness;
                foo.aroma = loadedBean.aroma;
                foo.ingredientID = loadedBean.ingredientID;
                rb.AddForce(new Vector2(0.0f, 2f), ForceMode2D.Impulse);
                break;
            case RoastLevel.MEDIUM:
                temp = Instantiate(roasts[1], transform.position, transform.rotation).gameObject;
                temp.GetComponent<RoastCoffeeData>().roastLevel = RoastLevel.MEDIUM;
                foo = temp.GetComponent<RoastedCoffeeBeans>().roast;
                foo.roastLevel = RoastLevel.MEDIUM;
                foo.acidity = loadedBean.acidity;
                foo.sweetness = loadedBean.sweetness;
                foo.aroma = loadedBean.aroma;
                foo.ingredientID = loadedBean.ingredientID;
                rb = temp.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0.0f, 2f), ForceMode2D.Impulse);
                break;
            case RoastLevel.DARK:
                temp = Instantiate(roasts[2], transform.position, transform.rotation).gameObject;
                temp.GetComponent<RoastCoffeeData>().roastLevel = RoastLevel.DARK;
                foo = temp.GetComponent<RoastedCoffeeBeans>().roast;
                foo.acidity = loadedBean.acidity;
                foo.sweetness = loadedBean.sweetness;
                foo.aroma = loadedBean.aroma;
                foo.ingredientID = loadedBean.ingredientID;
                rb = temp.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0.0f, 2f), ForceMode2D.Impulse);
                break;
            default:

                break;
        }
        StartCoroutine(hack());

    }
    private void SpawnGrounded()
    {
        GroundCoffeeData foo;
        GameObject temp;
        Rigidbody2D rb;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        switch (loadedType)
        {
            case RoastLevel.LIGHT:
                temp = Instantiate(grounds[0], transform.position, transform.rotation).gameObject;
                temp.GetComponent<GroundedCoffeeBeans>().grind.roast = RoastLevel.LIGHT;
                foo = temp.GetComponent<GroundedCoffeeBeans>().grind;
                foo.acidity = loadedBean.acidity;
                foo.sweetness = loadedBean.sweetness;
                foo.aroma = loadedBean.aroma;
                foo.ingredientID = loadedBean.ingredientID;
                Debug.Log("Spawned id is" + foo.ingredientID);Debug.Log("Spawned id is" + foo.ingredientID);
                rb = temp.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0.0f, 6f), ForceMode2D.Impulse);
                break;
            case RoastLevel.MEDIUM:
                temp = Instantiate(grounds[1], transform.position, transform.rotation).gameObject;
                temp.GetComponent<GroundedCoffeeBeans>().grind.roast = RoastLevel.MEDIUM;
                foo = temp.GetComponent<GroundedCoffeeBeans>().grind;
                foo.acidity = loadedBean.acidity;
                foo.sweetness = loadedBean.sweetness;
                foo.aroma = loadedBean.aroma;
                foo.ingredientID = loadedBean.ingredientID;
                Debug.Log("Spawned id is" + foo.ingredientID);
                rb = temp.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0.0f, 6f), ForceMode2D.Impulse);
                break;
            case RoastLevel.DARK:
                temp = Instantiate(grounds[2], transform.position, transform.rotation).gameObject;
                temp.GetComponent<GroundedCoffeeBeans>().grind.roast = RoastLevel.DARK;
                foo = temp.GetComponent<GroundedCoffeeBeans>().grind;
                foo.acidity = loadedBean.acidity;
                foo.sweetness = loadedBean.sweetness;
                foo.aroma = loadedBean.aroma;
                foo.ingredientID = loadedBean.ingredientID;
                Debug.Log("Spawned id is" + foo.ingredientID);
                rb = temp.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0.0f, 6f), ForceMode2D.Impulse);
                break;
            default:
                break;
        }
        
        StartCoroutine(hack());
    }

    private void ResetMortar()
    {
        hp = 0;
        loadedType = RoastLevel.NULL;
        loaded = false;
        spr.sprite = null;
    }

    private IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
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
