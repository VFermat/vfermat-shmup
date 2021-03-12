using UnityEngine;

public class ConditionDistGT : Condition
{
    Transform agent;
    Transform target;
    float maxDist;

    public ConditionDistGT(Transform ag, Transform ta, float dist) {
        agent = ag;
        target = ta;
        maxDist = dist;
    }

    public override bool Test() {
        return Vector2.Distance(agent.position, target.position) <= maxDist;
    }
}