using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new private string name = "New Item";
    public Sprite menuIcon;
    public Sprite pickupIcon;

    // put stats, icons, etc here

    public virtual void Use()
    {

    }

    public string GetItemName()
    {
        return name;
    }
}
