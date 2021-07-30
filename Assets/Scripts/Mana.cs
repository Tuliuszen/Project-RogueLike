using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int mana;
    public int maxMana;
    public int numOfMana;
    public Image[] manaImages;

    public PlayerUI manaPoints;

    void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            manaImages = manaPoints.manaPoints;
            maxMana = numOfMana;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TakeCareOfMana();
    }

    public void UseMana(int cost)
    {
        mana -= cost;       
    }

    public void GainMana(int amount)
    {
        mana += amount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    public void CheckHealth()
    {
        if (mana > numOfMana)
        {
            mana = numOfMana;
        }

        if (numOfMana > manaImages.Length)
        {
            numOfMana = manaImages.Length;
        }

        maxMana = numOfMana;
    }

    public void TakeCareOfMana()
    {
        if (manaPoints != null)
        {
            manaPoints.UpdateMana(mana, numOfMana);
            CheckHealth();
        }
        else
        {
            return;
        }
    }

    public void AddMana()
    {
        numOfMana++;
    }
}
