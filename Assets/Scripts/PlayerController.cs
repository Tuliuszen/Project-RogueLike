using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject crossHair;
    
    public Rigidbody2D rb;
    public Animator animator;

    public int damage = 1;

    public Camera cam;

    Shooting shooter;

    public Vector2 movementDirection;
    public Vector2 mousePosition;
    Vector2 lookDirection;

    [SerializeField] float moveSpeed = 5f;

    public void Start()
    {
        shooter = GetComponent<Shooting>();

        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shooter.Shoot(lookDirection);
        }

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
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);

        lookDirection = mousePosition - rb.position;
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
}
