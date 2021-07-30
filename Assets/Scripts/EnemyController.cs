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
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        StartCoroutine(MoveAction());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Move(Vector2 movementDirection)
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movementDirection);
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

    IEnumerator MoveAction()
    {
        MoveToTarget();
        yield return new WaitForSeconds(0.5f);
    }
}
