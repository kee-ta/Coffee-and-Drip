using UnityEngine;

public abstract class RoastGaugeBaseState
{
    public abstract void EnterState(RoastGaugeController roaster);

    public abstract void UpdateState(RoastGaugeController roaster);
}
