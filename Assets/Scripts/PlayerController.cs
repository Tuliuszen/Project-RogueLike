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

    [SerializeField] float moveSpeed = 5f;

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
        Move();
    }

    private void MoveInput()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movementDirection);
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
