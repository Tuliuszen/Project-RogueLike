using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject projectilePrefab;
    public Projectile projectile;

    public float projectileSpeed = 10f;
    public float destroyTime = 2f;

    int damage = 1;

    public void Shoot(Vector2 target)
    {
        
        projectile.InstantiateProjectile(projectilePrefab,SetProjectileDamage(),target, shootingPoint);
        GetComponent<Animator>().SetTrigger("isAttacking");
    }

    int SetProjectileDamage()
    {
        if (GetComponent<PlayerController>() != null)
        {
            PlayerController player = GetComponent<PlayerController>();
            damage = player.damage;
        }
        else if (GetComponent<EnemyController>() != null)
        {
            EnemyController enemy = GetComponent<EnemyController>();
            damage = enemy.damage;
        }
        else
        {
            return 0;
        }

        return damage;
    }
}
