using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 10;
    public int numOfHearts = 3;
    public int maxHealth;
    Image[] heartsImages;
    public HeartSystem hearts;

    [SerializeField]GameObject character;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            heartsImages = hearts.hearts;
            maxHealth = numOfHearts;
        }
    }

    private void Update()
    {
        TakeCareOfHearts();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        GetComponent<Animator>().SetTrigger("takeDamage");
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int healedHealth)
    {
        health += healedHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        Destroy(character);
        print("death");
    }

    public void CheckHealth()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (numOfHearts > heartsImages.Length)
        {
            numOfHearts = heartsImages.Length;
        }

        maxHealth = numOfHearts;
    }

    public void TakeCareOfHearts()
    {
        if (hearts != null)
        {
            hearts.UpdateHearts(health, numOfHearts);
            CheckHealth();
        }
        else
        {
            return;
        }
    }

    public void AddHeart()
    {
        numOfHearts++;
    }
}
