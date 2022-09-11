using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] float brewGravity = .05f;

    [Header("Progress Bar Settings")]
    [SerializeField] Transform progressContainer;
    [SerializeField] float power;
    [SerializeField] float decay;

    float spotPosition, spotSpeed, spotTimer, spotTargetPosition, brewPosition, brewVelocity, brewProgress;

    void FixedUpdate() {
        MoveSpot();
        MoveBrew();
        CheckBrewProgress();
    }

    private void MoveSpot () 
    {
        spotTimer -= Time.deltaTime;
        if(spotTimer <0)
        {
            spotTimer = Random.value * sweetSpotTimeRandomizer;
            spotTargetPosition = Random.value;
        }
        spotPosition = Mathf.SmoothDamp(spotPosition,spotTargetPosition, ref spotSpeed, motion);
        sweetSpot.position = Vector3.Lerp(bottomBound.position,topBound.position,spotPosition);
    }

    private void MoveBrew () 
    {
        if (Input.GetMouseButton(0))
        {
            brewVelocity += brewSpeed * Time.deltaTime;
        }
        brewVelocity -= brewGravity * Time.deltaTime;

        brewPosition += brewVelocity;
        if(brewPosition - brewSize/2 <= 0 && brewVelocity <0){
            brewVelocity = 0;
        }
        if(brewPosition + brewSize / 2 >= 1 && brewVelocity > 0){
            brewVelocity = 0;
        }
        brewPosition = Mathf.Clamp(brewPosition, brewSize/2 ,1-brewSize/2);
        brewZone.position = Vector3.Lerp(bottomBound.position,topBound.position,brewPosition);
    }
    private void CheckBrewProgress()
    {
        Vector3 barScale = progressContainer.localScale;
        barScale.y = brewProgress;
        progressContainer.localScale = barScale;

        float min = brewPosition - brewSize/2;
        float max = brewPosition + brewSize/2;

        if(min < spotPosition && spotPosition < max)
        {
            Debug.Log("Going!");
            brewProgress += power * Time.deltaTime;
            if(brewProgress >= 1)
            {
                Debug.Log("Done!");
            }
        }
        else
        {
            brewProgress -= decay * Time.deltaTime;
            if(brewProgress <= -2)
            {   
                Debug.Log("Try again!");
            }
        }
        brewProgress = Mathf.Clamp(brewProgress,0,1);
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
