using UnityEngine;

public abstract class BaseState 
{
    public StateMachine stateMachine;

    public EnemyScript enemy;
    //paradeigma to patrol state
    public abstract void Enter();// arxikopoihsh metavlitwn (px speed), animation
    
    public abstract void Perform();// enemy walking, na tsekarei an o paikths einai sto pedio volis tou
   
    public abstract void Exit();// stop walking, allagh animation, vgale oplo
}
