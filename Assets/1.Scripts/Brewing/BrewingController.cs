using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BrewingController : MonoBehaviour
{

    [Header("Brewing Area")]
    [SerializeField] Transform topBound;
    [SerializeField] Transform bottomBound;

    [Header("Sweet Spot Settings")]
    [SerializeField] Transform sweetSpot;
    [SerializeField] float motion = 3f; //smooth out movement
    [SerializeField] float sweetSpotTimeRandomizer = 3f; // time to movement

    [Header("Brew Zone Settings")]
    [SerializeField] Transform brewZone;
    [SerializeField] float brewSize = .15f;
    [SerializeField] float brewSpeed = 50f;
    [SerializeField] float brewGravity = .08f;

    [Header("Progress Bar Settings")]
    [SerializeField] Image progressContainer;
    [SerializeField] float power;
    [SerializeField] float decay;

    public int bodyScore = 0;

    public AudioClip blop;
    public AudioSource source;
    float blopPitch = 1.0f;
    float timeElasped = 0f;
    float pitchInterval = 0f;
    float pitchLowInterval = 0f;
    public static Action finishedBrewing;


    float spotPosition, spotSpeed, spotTimer, spotTargetPosition, brewPosition, brewVelocity, brewProgress;

    void FixedUpdate()
    {
        MoveSpot();
        MoveBrew();
        CheckBrewProgress();
    }

    private void MoveSpot()
    {
        spotTimer -= Time.deltaTime;
        if (spotTimer < 0)
        {
            spotTimer = UnityEngine.Random.value * sweetSpotTimeRandomizer;
            spotTargetPosition = UnityEngine.Random.value;
        }
        spotPosition = Mathf.SmoothDamp(spotPosition, spotTargetPosition, ref spotSpeed, motion);
        sweetSpot.position = Vector3.Lerp(bottomBound.position, topBound.position, spotPosition);
    }

    private void MoveBrew()
    {
        if (Input.GetMouseButton(0))
        {
            brewVelocity += brewSpeed * Time.deltaTime;
        }
        brewVelocity -= brewGravity * Time.deltaTime;

        brewPosition += brewVelocity;
        if (brewPosition - brewSize / 2 <= 0 && brewVelocity < 0)
        {
            brewVelocity = 0;
        }
        if (brewPosition + brewSize / 2 >= 1 && brewVelocity > 0)
        {
            brewVelocity = 0;
        }
        brewPosition = Mathf.Clamp(brewPosition, brewSize / 2, 1 - brewSize / 2);
        brewZone.position = Vector3.Lerp(bottomBound.position, topBound.position, brewPosition);
    }
    private void CheckBrewProgress()
    {
        float barScale = progressContainer.fillAmount;
        barScale = brewProgress;
        progressContainer.fillAmount = barScale;

        float min = brewPosition - brewSize / 2;
        float max = brewPosition + brewSize / 2;

        if (min < spotPosition && spotPosition < max)
        {
            Debug.Log("Going!");
            brewProgress += power * Time.deltaTime;
            pitchInterval += Time.deltaTime;
            if (pitchInterval > 0.4f)
            {
                source.pitch += 0.05f;
                pitchInterval = 0f;
            }
            if (barScale >= 1)
            {
                Debug.Log("Done!");
                finishedBrewing?.Invoke();
                source.Stop();
                brewProgress = 0;
                Reset();
                Debug.Log("Body score is " + bodyScore.ToString());
            }
        }
        else
        {
            brewProgress -= decay * Time.deltaTime;
            bodyScore--;
            pitchLowInterval += Time.deltaTime;
            if (pitchLowInterval > 0.4f)
            {
                if (source.pitch >= 0.9f)
                    source.pitch -= 0.05f;
                pitchLowInterval = 0f;
            }
            if (brewProgress <= -2)
            {
                Debug.Log("Try again!");
            }
        }
        brewProgress = Mathf.Clamp(brewProgress, 0, 1);
        timeElasped += Time.deltaTime;
        if (timeElasped > 0.5f)
        {
            //source.PlayOneShot(blop);
            timeElasped = 0;
        }
    }

    private void Reset()
    {
        progressContainer.fillAmount = 0;
        source.pitch = 1.0f;
        bodyScore = 0;
    }

    private void OnEnable() {
        source.Play();
    }
    private void OnDisable() {
        source.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
        bodyScore = 0;
        source.volume = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
