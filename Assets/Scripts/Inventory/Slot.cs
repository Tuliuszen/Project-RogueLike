using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    
    public bool empty;
    public Sprite icon;
    public Transform slotIcon;

    public int id;
    public string type;
    public string description;

    void Start()
    {
        slotIcon = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        slotIcon.GetComponent<Image>().sprite = icon;
    }
}
