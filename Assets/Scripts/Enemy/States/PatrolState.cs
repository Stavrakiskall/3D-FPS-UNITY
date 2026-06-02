using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointNo;

    public float waittimer ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Enter()
    {
        
    }
    
    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
   
    public override void Exit() 
    {
        
    }

    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)// an apostasi apo to waypoint einai mikroterh apo 0.2 tote kanei 2o check
        {
            waittimer += Time.deltaTime;
            
            if (waittimer > 3f)
            {
                if (waypointNo < enemy.path.waypoints.Count - 1)//kitaei se pio waypoint einai ,an auto einai mikrotero apo to enemy.path.count -1 ,tote kane aukshsh 
                {
                    waypointNo++;
                }
                else
                {
                    waypointNo = 0;
                }
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointNo].position);//to navmesh agent pernei to position toy waypoint kai tou leei pou na paei dhladh sto epomeno way point
                waittimer = 0f;
                }
              
            
            
        }
    }
}
