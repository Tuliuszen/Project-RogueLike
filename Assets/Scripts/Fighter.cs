using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int damage = 1;
    public float attackSpeed = 0.5f;

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
        AttackAction();
    }

    public void Attack()
    {
        if (melee)
        {
            return;
        }
        else
        {
            shooter.Shoot(lookDirection - GetComponent<Rigidbody2D>().position);
        }
    }

    public void AddBasicDamage(int amount)
    {
        damage += amount;
    }

    void AttackAction()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating(nameof(Attack), 0.01f, attackSpeed);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Attack");
        }
    }
}
