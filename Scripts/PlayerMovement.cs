using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 5;

    private Vector3 tartgetPos;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            SetTargetPosition();
        }
        if (isMoving)
        {
            Move();
        }
    }

    void SetTargetPosition()
    {
        tartgetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tartgetPos.y = transform.position.y;

        isMoving = true;
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void Move()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, tartgetPos, speed * Time.deltaTime);
        if(transform.position == tartgetPos)
        {
            isMoving = false;
        }
    }
}
