using UnityEngine;

public class SpawnerStateManager : MonoBehaviour
{
    SpawnerBaseState currentState;
    public SpawnerIdleState idleState = new SpawnerIdleState();
    public SpawnerActiveState activeState = new SpawnerActiveState();
    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void StateSwitch(SpawnerBaseState state){
        currentState = state;
        state.EnterState(this);
    }
}
