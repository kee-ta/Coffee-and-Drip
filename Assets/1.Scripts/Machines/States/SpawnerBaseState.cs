using UnityEngine;

public abstract class SpawnerBaseState 
{
    public abstract void EnterState(SpawnerStateManager spawner);

    public abstract void UpdateState(SpawnerStateManager spawner);

    public abstract void OnCollisionEnter(SpawnerStateManager spawner);
}
 