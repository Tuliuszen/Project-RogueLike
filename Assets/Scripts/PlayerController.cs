using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject crossHair;
    
    public Rigidbody2D rb;
    public Animator animator;

    public Camera cam;

    public Vector2 movementDirection;
    public Vector2 mousePosition;

    public Vector2 lastMoveDir;

    public float moveSpeed = 5f;

    public void Start()
    {
        Cursor.visible = false;

        rb.freezeRotation = true;
    }

    void Update()
    {
        MoveInput();

        MoveCrossHair();

        MovementAnimation();

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Move(moveSpeed,movementDirection);
    }

    private void MoveInput()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
    }

    public void Move(float speed, Vector2 direction)
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);

        lastMoveDir = movementDirection;
    }


    private void MovementAnimation()
    {
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);
    }
    
    void MoveCrossHair()
    {
        crossHair.transform.position = mousePosition;
    }

    public Vector2 GetLookDirection()
    {
        return mousePosition;
    }

    public bool HasManaForSkill(int skillCost, int currentMana)
    {
        if (currentMana >= skillCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
