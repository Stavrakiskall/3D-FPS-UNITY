using UnityEngine;

public class Keypad : Interactable
{
    public GameObject door;
    private bool doorOpen;
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("isopen", doorOpen);
        Debug.Log("Interacted with " + gameObject.name);
    }
}