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
    [SerializeField] List<Sprite> groundedSprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer frontMortar, backMortar;

    [SerializeField] private SpriteRenderer spr;

    bool isColliding = false;

    public GroundedCoffeeBeans grinds;

    private int currentImage = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<RoastedCoffeeBeans>())
        {
            Destroy(other.gameObject);
            mounted?.Invoke();
            loaded = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }

        if (other.gameObject.GetComponent<Pestle>() && loaded)
        {
            FadeCover();
            Debug.Log("Hit!!");
            if (currentImage < (lightRoast.Count - 2))
            {
                currentImage++;
                spr.sprite = lightRoast[currentImage];
            }
        }
        FadeCover();
        Debug.Log("Mortar Trigger");
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (isColliding) return;
        isColliding = true;
        if (col.gameObject.GetComponent<RoastedCoffeeBeans>())
        {
            Destroy(col.gameObject);
            mounted?.Invoke();
            loaded = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            switch (col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel)
            {
                case RoastLevel.LIGHT:
                    SetSprite(col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel);
                    break;
                case RoastLevel.MEDIUM:
                    SetSprite(col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel);
                    break;
                case RoastLevel.DARK:
                    SetSprite(col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel);
                    break;
                default:

                    break;
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
        Debug.Log("exit!!");
        StartCoroutine(Reset());
        FadeCover(false);

    }
    void OnMouseUp()
    {
        /*
        if (currentImage >= (sprites.Count - 2))
        {
            spr.sprite = sprites[sprites.Count - 1];
            Instantiate(grinds, transform.position, transform.rotation);
            currentImage = 0;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
        */
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
    }

    IEnumerator Reset()
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
