using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public int health;
    public int damage;
    public int mana;
    public int shield;

    public bool addHeart = false;
    public bool addMana = false;
    public bool addShield = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Mana>().GainMana(mana);
            collision.GetComponent<Health>().Heal(health);
            collision.GetComponent<Shield>().GainShield(shield);
            collision.GetComponent<PlayerController>().AddBasicDamage(damage);

            if (addHeart)
                collision.GetComponent<Health>().AddHeart();
            if (addMana)
                collision.GetComponent<Mana>().AddMana();
            if (addShield)
                collision.GetComponent<Shield>().AddShieldPoint();

            Destroy(gameObject);
        }
    }
}
