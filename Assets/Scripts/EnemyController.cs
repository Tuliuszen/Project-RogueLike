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
    public bool shooter = false;
    public GameObject projectile;
    Transform player;
    public Projectile projectileScript;
    public int pDMG = 1;
    Rigidbody2D rb;
    Vector2 direction, movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;

        if (!rotates)
            rb.freezeRotation = true;
    }

    private void Update()
    {
        Move();
        StartCoroutine(ShootingPlayer());
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
        rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
    }

    IEnumerator ShootingPlayer()
    {
        ShootPlayer();
        yield return new WaitForSecondsRealtime(3);
    }
    
    void ShootPlayer()
    {
        if (shooter)
        {
            projectileScript.InstantiateProjectile(projectile, pDMG, player.position, gameObject.transform);
            //GetComponent<Animator>().SetTrigger("isAttacking");
        }
        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //if warrior check for immunity
            if(collision.gameObject.GetComponent<Warrior>()!= null)
            {
                if (collision.gameObject.GetComponent<Warrior>().immune == true)
                    return;
            } 
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    
}
