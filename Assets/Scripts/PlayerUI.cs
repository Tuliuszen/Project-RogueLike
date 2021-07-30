using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    //Mana System
    public Image[] manaPoints;
    public Sprite fullMana;
    public Sprite emptyMana;

    //Heart system
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //Shield System
    public Image[] shields;
    public Sprite fullShield;
    public Sprite emptyShield;


    public void UpdateMana(int mana, int numOfMana)
    {
        for (int i = 0; i < manaPoints.Length; i++)
        {
            if (i < mana)
            {
                manaPoints[i].sprite = fullMana;
            }
            else
            {
                manaPoints[i].sprite = emptyMana;
            }

            if (i < numOfMana)
            {
                manaPoints[i].enabled = true;
            }
            else
            {
                manaPoints[i].enabled = false;
            }
        }
    }

    public void UpdateHearts(int health, int numOfHearts)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void UpdateShield(int shield, int numOfShield)
    {
        for (int i = 0; i < shields.Length; i++)
        {
            if (i < shield)
            {
                shields[i].sprite = fullShield;
            }
            else
            {
                shields[i].sprite = emptyShield;
            }

            if (i < numOfShield)
            {
                shields[i].enabled = true;
            }
            else
            {
                shields[i].enabled = false;
            }
        }
    }

}
