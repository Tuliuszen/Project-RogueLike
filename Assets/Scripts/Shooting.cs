using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject projectilePrefab;
    public Projectile projectile;

    int damage = 1;

    public void Shoot(Vector2 target)
    {
        
        projectile.InstantiateProjectile(projectilePrefab,SetProjectileDamage(),target, shootingPoint);
        GetComponent<Animator>().SetTrigger("isAttacking");
    }

    public int SetProjectileDamage()
    {
        if (GetComponent<PlayerController>() != null)
        {
            Fighter player = GetComponent<Fighter>();
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
