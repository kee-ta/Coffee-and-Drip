using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class PlayerController : SingletonController<PlayerController>
{
    public Quest currentQuest;
    public AudioClip clip;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

    }

    public bool EvaluateQuest(RoastCoffeeData data)
    {
        List<bool> checks = new List<bool>();
        for (int i = 1; i < currentQuest.clearConditions.Count; i++)
        {
            switch (currentQuest.clearConditions[i].type)
            {
                case QuestType.ACID:
                    if (data.acidity >= currentQuest.clearConditions[i].Value)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.AROMA:
                    if (data.aroma >= currentQuest.clearConditions[i].Value)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.SWEET:
                    if (data.sweetness >= currentQuest.clearConditions[i].Value)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.FLAVOR_BITTER:
                    if (data.flavor == Flavor.BITTER)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.FLAVOR_BITTERSWEET:
                    if (data.flavor == Flavor.BITTERSWEET)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.FLAVOR_CHOCOLATE:
                    if (data.flavor == Flavor.CHOCOLATE)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.FLAVOR_EARTHY:
                    if (data.flavor == Flavor.EARTHY)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.FLAVOR_FRUITY:
                    if (data.flavor == Flavor.FRUITY)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.FLAVOR_NUTTY:
                    if (data.flavor == Flavor.NUTTY)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                case QuestType.FLAVOR_SOUR:
                    if (data.flavor == Flavor.SOUR)
                    {
                        checks.Add(true);
                    }
                    else
                    {
                        checks.Add(false);
                    }
                    break;
                default:

                    break;
            }
        }
        return checks.All(x => x == true);

    }

    // Update is called once per frame
    private void Update()
    {


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial"))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(MoveRight());
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(MoveLeft());
            }
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void FixedUpdate()
    {

    }

    private void Move()
    {


    }

    public IEnumerator MoveRight()
    {
        //source.PlayOneShot(clip);
        float time = 0;
        while (Camera.main.transform.position != new Vector3(19.5f, 0.0f, -10.0f))
        {
            Camera.main.transform.position = Vector3.Lerp(new Vector3(0.0f, 0.0f, -10.0f), new Vector3(19.5f, 0.0f, -10.0f), time * 1f);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator MoveLeft()
    {
        //source.PlayOneShot(clip);
        float time = 0;
        while (Camera.main.transform.position != new Vector3(0.0f, 0.0f, -10.0f))
        {
            Camera.main.transform.position = Vector3.Lerp(new Vector3(19.5f, 0.0f, -10.0f), new Vector3(0.0f, 0.0f, -10.0f), time * 1f);
            time += Time.deltaTime;
            yield return null;
        }

    }
}
