using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public bool immune = false;
    public GameObject superSlash;
    public Projectile projectile;
    PlayerController pController;
    Transform shootingPoint;
    Fighter fight;
    int sslashDmg;

    int slashCost = 1;
    readonly int rageCost = 2;
    readonly int immunityCost = 4;

    float prevoisAS;
    void Start()
    {
        pController = GetComponent<PlayerController>();
        shootingPoint = GetComponent<Shooting>().shootingPoint;
        fight = GetComponent<Fighter>();
        prevoisAS = fight.attackSpeed;

         sslashDmg = fight.damage + 3;
    }



    void Update()
    {
        CheckForUsingSkills();
    }
    
    void CheckForUsingSkills()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Slash();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Rage();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Immunity();
        }
    }

    void Rage()
    {
        if (pController.HasManaForSkill(rageCost, GetComponent<Mana>().mana))
        {
            StartCoroutine(InRage());
            GetComponent<Mana>().mana -= rageCost;
        }

        return;
        //buff to dmg and speed 
        //smalls cooldowns and makes slash cost nothing
        //cost 2
    }

    IEnumerator InRage()
    {
        fight.attackSpeed = 0.02f;
        fight.damage += 2;
        slashCost = 0;
        GetComponent<SpriteRenderer>().color = new Color(100, 0, 0);
        yield return new WaitForSecondsRealtime(2);
        fight.attackSpeed = prevoisAS;
        fight.damage -= 2;
        slashCost = 1;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    void Slash()
    {
        if (pController.HasManaForSkill(slashCost, GetComponent<Mana>().mana))
        {
            projectile.InstantiateProjectile(superSlash, sslashDmg, GetTarget(), shootingPoint);
            GetComponent<Animator>().SetTrigger("isAttacking");
            GetComponent<Mana>().mana -= slashCost;
        }
        return;
        //cost 1
    }

    //Warriors ult gives immunity for 3 seconds and EFFECT(to add later) also as a bonus it adds 1 damage forever so its a very strong power Cost at least 6
    void Immunity()
    {
        if (pController.HasManaForSkill(immunityCost, GetComponent<Mana>().mana))
        {
            GetComponent<Fighter>().damage += 1;
            StartCoroutine(ImmunityTime());
            GetComponent<Mana>().mana -= immunityCost;
        }
        return;
    }
    
    IEnumerator ImmunityTime()
    {
        immune = true;
        GetComponent<SpriteRenderer>().color = new Color(100, 100, 0);
        yield return new WaitForSecondsRealtime(3);
        immune = false;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    Vector2 GetTarget()
    {
        return pController.GetLookDirection() - GetComponent<Rigidbody2D>().position;
    }
}
