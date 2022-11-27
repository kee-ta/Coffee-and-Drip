using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RawCoffeeSack : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    string sackName;
    public GreenBeanData greenBeanData;

    public RoastModifier lightMod;
    public RoastModifier medMod;
    public RoastModifier darkMod;

    [Header("LightMods")]
    public int lightSweet, lightAcid, lightAroma;
    [Header("MedMods")]
    public int medSweet, medAcid, medAroma;
    [Header("DarkMods")]
    public int darkSweet, darkAcid, darkAroma;

    // Start is called before the first frame update
    void Start()
    {
        //medMod = new RoastModifier(medMod.sweetMod,medMod.acidMod,medMod.aromaMod,medMod.flavorMod);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        RawCoffeeBeans temp = Instantiate(prefab, transform.position, transform.rotation).gameObject.GetComponent<RawCoffeeBeans>();
        temp.rawStats.acidity = greenBeanData.acidity;
        temp.rawStats.sweetness = greenBeanData.sweetness;
        temp.rawStats.aroma = greenBeanData.aroma;
        temp.rawStats.ingredientID = greenBeanData.ingredientID;

        temp.rawStats.light.sweetMod = this.lightSweet;
        temp.rawStats.light.acidMod = this.lightAcid;
        temp.rawStats.light.aromaMod = this.lightAroma;

        temp.rawStats.medium.sweetMod = this.medSweet;
        temp.rawStats.medium.acidMod = this.medAcid;
        temp.rawStats.medium.aromaMod = this.medAroma;

        temp.rawStats.dark.sweetMod = this.darkSweet;
        temp.rawStats.dark.acidMod = this.darkAcid;
        temp.rawStats.dark.aromaMod = this.darkAroma;

        Debug.Log("Mods are:" + temp.rawStats.medium.acidMod.ToString() + "/"
                                                   + temp.rawStats.medium.sweetMod.ToString() + "/"
                                                   + temp.rawStats.medium.aromaMod.ToString());
        Debug.Log("Spawning!");
    }

    public void SpawnRandom()
    {
        //Instantiate();
    }

    public void OnPointerDown(PointerEventData data)
    {
        Spawn();
    }

    private void OnMouseUp()
    {
        Spawn();
    }
}
