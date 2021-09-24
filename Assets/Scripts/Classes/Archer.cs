using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject trap;
    PlayerController pController;
    Transform shootingPoint;
    public Projectile projectile;
    public float dashSpeed = 20;
    float previousSpeed;

    readonly int dashCost = 1;
    readonly int multiShotCost = 1;
    readonly int trapCost = 8;

    void Start()
    {
        pController = GetComponent<PlayerController>();
        shootingPoint = GetComponent<Shooting>().shootingPoint;
        previousSpeed = pController.moveSpeed;
    }

    void Update()
    {
        CheckForUsingSkills();
    }

    int ArrowDamage =>  GetComponent<Fighter>().damage;

    void CheckForUsingSkills()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Multishot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Dash();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ULT_Trap();
        }
    }

    void Multishot()//One day to update to three shots at once at different angles
    {
        if (pController.HasManaForSkill(multiShotCost, GetComponent<Mana>().mana))
        {
            StartCoroutine(TripleShot());
            GetComponent<Mana>().mana -= multiShotCost;
        }
    }

    IEnumerator TripleShot()
    {
        for (int i = 0; i < 3; i++)
        {
            projectile.InstantiateProjectile(arrow, ArrowDamage, GetTarget(), shootingPoint);
            GetComponent<Animator>().SetTrigger("isAttacking");
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void Dash()
    {
        if (pController.HasManaForSkill(dashCost, GetComponent<Mana>().mana))
        {
            if (pController.movementDirection.x != 0 || pController.movementDirection.y != 0)
            {
                StartCoroutine(Dashing());
                GetComponent<Mana>().mana -= dashCost;
            }
            else
            {
                print("not moving");
            }
        }
        //Does not work i dont know why :p
        //pController.Move(pController.moveSpeed, pController.GetLookDirection() -rb.position);
    }

    IEnumerator Dashing()
    {
        pController.moveSpeed = dashSpeed;
        yield return new WaitForSecondsRealtime(0.2f);
        pController.moveSpeed = previousSpeed;
    }

    

    Vector2 GetTarget()
    { 
        return pController.GetLookDirection() - GetComponent<Rigidbody2D>().position;
    }

    //ULT a trap that kills EVERYTHING
    void ULT_Trap()
    {
        if (pController.HasManaForSkill(trapCost, GetComponent<Mana>().mana))
        {
            Instantiate(trap, shootingPoint);
            GetComponent<Mana>().mana -= trapCost;
        }
        else
            print("not enough mana");
    }
}
