using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PLAYERINPUT playerInput;
    public PLAYERINPUT.OnFootActions onFoot;
    private PlayerMovement playerMove;
    
    private PlayerLook playerLook;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PLAYERINPUT();
        onFoot = playerInput.OnFoot;
        playerMove = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();
        
        onFoot.Jump.performed += ctx => playerMove.Jump();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    private void Update()
    {
        playerMove.ProcessMove(onFoot.Move.ReadValue<Vector2>());
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>()); 
    }
}
