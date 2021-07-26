using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage = 1;
    public float moveSpeed = 1f;
    public bool movesToPlayer = true;
    Rigidbody2D rb;
    Vector2 playerPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }


    private void Move(Vector2 movementDirection)
    {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void GetPlayerPosition()
    {
        playerPos = FindObjectOfType<PlayerController>().GetComponent<Transform>().position;
    }

    void MoveToTarget()
    {
        if (movesToPlayer)
        {
            GetPlayerPosition();
            Move(playerPos);
        }
    }
}
