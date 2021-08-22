using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage = 1;
    public float moveSpeed = 1f;
    float angle;
    public bool movesToPlayer = true;
    public bool rotates = false;
    public Transform player;
    Rigidbody2D rb;
    Vector2 direction, movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if(!rotates)
            rb.freezeRotation = true;
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void Move()
    {
        if (movesToPlayer)
        {
            direction = player.position - transform.position;

            Rotate();

            direction.Normalize();
            movement = direction;
        }
    }

    void Rotate()
    {
        if (rotates)
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    
}
