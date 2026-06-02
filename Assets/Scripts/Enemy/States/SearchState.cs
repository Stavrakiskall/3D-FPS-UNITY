using UnityEngine;

public class SearchState : BaseState
{
    private float SearchTimer;
    private float moveTimer;

    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnownPos); //prwti douleia einai na paei stin teleutaia thesi pou me eide
        SearchTimer = 0;
    }
    
    public override void Exit() {}

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }

        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            SearchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            if (SearchTimer > 10)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
}
