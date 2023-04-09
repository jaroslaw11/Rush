using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIChasingState : TAIState
{
    NavMeshAgent agent;

    public override void Initialize()
    {
        base.Initialize();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void UpdateAnimation()
    {
        animator.SetBool("isWalk", true);
    }

    private void Update()
    {
        if (agent == null) return;
        agent.SetDestination(target.position);
    }
}
