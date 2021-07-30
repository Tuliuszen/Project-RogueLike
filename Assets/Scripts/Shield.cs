using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public int shield;
    public int maxShield;
    public int numOfShield;
    public Image[] shieldImages;

    public PlayerUI shieldPoints;

    void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            shieldImages = shieldPoints.manaPoints;
            maxShield = numOfShield;
        }
    }

    void Update()
    {
        TakeCareOfShield();
    }

    public void GainShield(int amount)
    {
        shield += amount;
        if (shield > maxShield)
        {
            shield = maxShield;
        }
    }

    public void CheckShield()
    {
        if (shield > numOfShield)
        {
            shield = numOfShield;
        }

        if (numOfShield > shieldImages.Length)
        {
            numOfShield = shieldImages.Length;
        }

        maxShield = numOfShield;
    }

    public void TakeCareOfShield()
    {
        if (shieldPoints != null)
        {
            shieldPoints.UpdateShield(shield, numOfShield);
            CheckShield();
        }
        else
        {
            return;
        }
    }

    public void AddShieldPoint()
    {
        numOfShield++;
    }

    public void TakeShield(int damage)
    {
        shield -= damage;
        GetComponent<Animator>().SetTrigger("takeDamage");
    }

    public bool IsShieldEmpty()
    {
        if (shield > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
