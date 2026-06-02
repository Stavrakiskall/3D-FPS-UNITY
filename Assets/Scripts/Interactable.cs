using UnityEngine;

public  abstract class Interactable : MonoBehaviour
{
    

    public string promptMessage;

    public void BaseInteract()
    {
        Interact();
    }
    
    protected virtual void Interact()
    {
        //einai keno giati den kseroume ti tha kanoume me to kathe antikeimeno
        
    }
    
}
