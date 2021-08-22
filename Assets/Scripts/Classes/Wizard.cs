using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{  
    public GameObject fireball;
    public Transform teleportTarget;
    public Projectile projectile;
    Transform shootingPoint;
    PlayerController pController;
    
    readonly int fireballDamageMultiplier = 3;
    readonly int fireballCost = 2;
    readonly int tpCost = 1;

    private void Start()
    {
        pController = GetComponent<PlayerController>();
        shootingPoint = GetComponent<Shooting>().shootingPoint;
    }

    void Update()
    {
        teleportTarget.position = GetComponent<PlayerController>().GetLookDirection();
        CheckForUsingSkills();
    }

    void CheckForUsingSkills()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fireball();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TeleportSkill();
        }
    }
    
    void Fireball()
    {
        if(pController.HasManaForSkill(fireballCost,GetComponent<Mana>().mana))
        {
            projectile.InstantiateProjectile(fireball, FireballDamage, GetTarget(), shootingPoint);
            GetComponent<Mana>().mana -= fireballCost;
        }
        else
        {
            print("not enough mana");
        }
            
    }

    void TeleportSkill()
    {
        if (pController.HasManaForSkill(tpCost, GetComponent<Mana>().mana))
        {
            Teleportation();
            GetComponent<Mana>().mana -= tpCost; 
            print("teleportation");
            TestHit();
        }
        else
        {
            print("not enough mana");
        }
    }

    int FireballDamage => fireballDamageMultiplier * GetComponent<Fighter>().damage;

    Vector2 GetTarget()
    {
        return pController.GetLookDirection() - GetComponent<Rigidbody2D>().position;
    }

    private void TestHit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hits = Physics2D.GetRayIntersectionAll(ray, 1500f);

        foreach(var hit in hits)
        {
            print($"Mouse is over {hit.collider.name}");

            if (hit.collider.CompareTag("Void") || hit.collider.CompareTag("Walls"))
            {
                return;
            }
            else
            {
                Teleportation();
            }
        }
    }

    public void Teleportation()
    {
        gameObject.transform.position = teleportTarget.position;
    }
}
