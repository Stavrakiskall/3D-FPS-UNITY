using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CharacterController controller; 
    public float speed = 5f;
    private Vector3 PlayerVelocity;
    
    
    
    private bool isGrounded;
    public float jumpPower = 1.5f;
    private float gravity = -9.8f;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 movementdirection =  Vector3.zero;
        movementdirection.x = input.x;
        movementdirection.z= input.y;
        controller.Move(transform.TransformDirection(movementdirection) * speed * Time.deltaTime);
        
        // swsth efarmogh varithtas
        PlayerVelocity.y += gravity * Time.deltaTime; // apply gravity ston paixth
        if( isGrounded && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = -2f;
        }
        
        
        controller.Move(PlayerVelocity * Time.deltaTime); 

    }
    public void Jump()
    {
        if (isGrounded)
        {
            PlayerVelocity.y = Mathf.Sqrt(jumpPower * -3f * gravity);
        }
    }

}
