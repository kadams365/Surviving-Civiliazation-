using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public int maxXPosition = 100;
    public int minXPosition = -100;

    public int maxYPosition = 100;
    public int minYPosition = -100;

    public int edgesize;
    public float movementSpeed;
    public float movementTime;

    public Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        MouseMovementInput();
        KeyboardMovementInput();
        newPosition = new Vector3(Mathf.Clamp(newPosition.x, minXPosition, maxXPosition), newPosition.y, Mathf.Clamp(newPosition.z, minYPosition, maxYPosition));
    }

    void MouseMovementInput()
    {
        if (Input.mousePosition.y > Screen.height - edgesize)
        {
            newPosition += transform.forward * movementSpeed;
        }
        if (Input.mousePosition.y < edgesize)
        {
            newPosition += transform.forward * -movementSpeed;
        }
        if (Input.mousePosition.x > Screen.width - edgesize)
        {
            newPosition += transform.right * movementSpeed;
        }
        if (Input.mousePosition.x < edgesize)
        {
            newPosition += transform.right * -movementSpeed;
        }
    }

    void KeyboardMovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += transform.forward * -movementSpeed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += transform.right * -movementSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += transform.right * movementSpeed;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
}
