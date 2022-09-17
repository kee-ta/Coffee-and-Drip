using UnityEngine;

public class SpawnerIdleState : SpawnerBaseState
{
    public override void EnterState(SpawnerStateManager spawner){
        Debug.Log("I'm idling!");
    }

    public override void UpdateState(SpawnerStateManager spawner){
        if(false){

        } else {
            spawner.StateSwitch(spawner.idleState);
        }
    }

    public override void OnCollisionEnter(SpawnerStateManager spawner){

    }
}
