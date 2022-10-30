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
    [SerializeField] public List<RoastedCoffeeBeans> roasts = new List<RoastedCoffeeBeans>();
    [SerializeField]private SpriteRenderer spr;

    private int hp = 0;
    private RoastLevel loadedType;

    bool isColliding = false;

    private int currentImage = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<RoastedCoffeeBeans>() && !loaded)
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
        Debug.Log("Mortar Trigger2DEnter");
        if (isColliding) return;
        isColliding = true;
        if (col.gameObject.GetComponent<RoastedCoffeeBeans>() && !loaded)
        {
            Destroy(col.gameObject);
            mounted?.Invoke();
            loaded = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            SetSprite(col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel);
            loadedType = col.gameObject.GetComponent<RoastedCoffeeBeans>().roast.roastLevel;
        }
        if (col.gameObject.GetComponent<Pestle>() && loaded)
        {
            if ((hp <= 2))
            {
                hp++;
                SetSprite(loadedType, hp);
            }
            if(hp >= 2)
            {
                gameObject.GetComponent<Collider2D>().isTrigger = false;
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
        if(!loaded)
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
        Debug.Log("exit!!");
        isColliding = false;
        StartCoroutine(Reset());
        if(!loaded)
        FadeCover(false);

    }
    void OnMouseUp()
    {
        if(!loaded)
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
        if(hp>=2)
        {
            SpawnGrounded();
        }
    }

    private void SpawnGrounded () 
    {
        
    }

    private void ResetMortar () 
    {
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
