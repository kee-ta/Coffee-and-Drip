using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoastGaugeController : MonoBehaviour
{
    RoastGaugeBaseState currentState;
    public RoastGaugeLightState lightState = new RoastGaugeLightState();
    public RoastGaugeDarkState darkState = new RoastGaugeDarkState();
    public RoastGaugeMediumState mediumState = new RoastGaugeMediumState();
    // Start is called before the first frame update
    void Start()
    {
        currentState = lightState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void StateSwitch(RoastGaugeBaseState state){
        currentState = state;
        state.EnterState(this);
    }
}
