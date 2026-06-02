using UnityEngine;

public class StateMachine : MonoBehaviour
{
    
    public BaseState activeState;
    //activestate = patrol, newstate = attack
    public void Initialize()
    {
        ChangeState( new PatrolState());
    }
    void Update()
    {
        if(activeState != null)
        {
         activeState.Perform();//mas psaxnei - kovei voltes            
        }
    }
    
    public void ChangeState(BaseState newState) // ChangeState(attack)
    {
        if (activeState != null)
        {
            activeState.Exit();//giati thelw na kleisw smooth to patrol state
        }
        
        activeState = newState;
        if (activeState != null)
        {
            activeState.stateMachine = this;//epivevaiwnw oti ontws allaksa state
            activeState.enemy = GetComponent<EnemyScript>();
            activeState.Enter(); //KANE TIS PROETIMASIES GIA TO ATTAC STATE
        }
    }
}