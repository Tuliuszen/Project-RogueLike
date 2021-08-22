using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int damage = 1;
    public float attackSpeed = 1;

    public bool melee = false;

    Shooting shooter;

    Vector2 lookDirection;

    void Start()
    {
        shooter = GetComponent<Shooting>();
    }

    void Update()
    {
        lookDirection = GetComponent<PlayerController>().GetLookDirection();
        if (Input.GetButtonDown("Fire1"))
        {
            shooter.Shoot(lookDirection - GetComponent<Rigidbody2D>().position);
        }
    }

    public void Attack()
    {
        if (melee)
        {
            return;
        }
        else
        {
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {
        shooter.Shoot(lookDirection - GetComponent<Rigidbody2D>().position);
        yield return new WaitForSeconds(attackSpeed);
    }

    public void AddBasicDamage(int amount)
    {
        damage += amount;
    }
}
