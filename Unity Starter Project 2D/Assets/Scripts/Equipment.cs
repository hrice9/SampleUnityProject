using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    // add equipment here
    [SerializeField] private EquipSlot equipSlot;

    public override void Use()
    {
        base.Use();
        GameController.instance.Equip(this);
    }

    public EquipSlot GetEquipSlot()
    {
        return equipSlot;
    }
}
