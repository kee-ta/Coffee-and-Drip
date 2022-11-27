using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Controller : MonoBehaviour
{
    public ParticleSystem fireworks;
    // Start is called before the first frame update
    void Start()
    {
        fireworks.Stop();
    }

    private void FireAndStop()
    {
        fireworks.Play();
        StartCoroutine(StopOnDelay());
    }
    IEnumerator StopOnDelay()
    {
        yield return new WaitForSecondsRealtime(5);
        fireworks.Stop();
        yield return null;
    }
    private void OnEnable()
    {
        CoffeeResultController.questComplete += FireAndStop;
    }
    private void OnDisable()
    {
        CoffeeResultController.questComplete -= FireAndStop;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
