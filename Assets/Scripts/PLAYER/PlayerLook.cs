using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    
    private float Rotation = 0f;

    
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public bool isCursorLocked = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorLocked = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCursorLocked = false;
        }
        else if (Input.GetMouseButton(0) && !isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCursorLocked = true;
        }
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        // panw kato
        Rotation -= (mouseY * Time.deltaTime ) * ySensitivity; // + gia inverted camera - gia kanonikh camera
        Rotation = Mathf.Clamp(Rotation, -80f , 80f); // math.clamp -> gia na valoume oria sto xRotation
        
        cam.transform.localRotation = Quaternion.Euler(Rotation, 0f, 0f); 
        // deksia aristera
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity); 
        
    }
}
