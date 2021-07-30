using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitEffect;
    readonly float destroyEffectTime = 0.05f;
    public int projectileDamage;

    public bool isPlayer = true;

    public float projectileSpeed = 10f;
    public float destroyTime = 2f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CollisionCheck(collision))
            return;

        SpawnEffect();

        collision.GetComponent<Health>().TakeDamage(projectileDamage);
        
        Destroy(gameObject);
    }

    public void InstantiateProjectile(GameObject projectilePrefab, int damage, Vector2 target, Transform shootingPoint)
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.velocity = target * projectileSpeed;
        projectile.transform.Rotate(0f, 0f, Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg);

        projectileDamage = damage;

        Destroy(projectile, destroyTime);
    }

    public void SpawnEffect()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, destroyEffectTime);
    }

    public void DestroyProjectile()
    {
        SpawnEffect();
        Destroy(gameObject);
    }

    private bool CollisionCheck(Collider2D collision)
    {
        if (isPlayer && collision.gameObject.GetComponent<PlayerController>())
            return true;

        if (collision.CompareTag("Walls"))
        {
            DestroyProjectile();
            return true;
        }

        if (collision.GetComponent<Health>() == null)
            return true;


        return false;
    }
}
