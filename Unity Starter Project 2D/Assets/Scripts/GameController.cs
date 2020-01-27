using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;
    public static GameController instance;
    public List<Item> inventory;
    public Equipment[] equipment;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Warning! Multiple instances of GameController instance!");
            return;
        }
        instance = this;
        inventory = new List<Item>();
        equipment = new Equipment[System.Enum.GetNames(typeof(EquipSlot)).Length];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // return the mouse position
    public Vector3 GetMousePosition() 
    {
        return mousePosition;
    }
    
    // add an item to the inventory list
    public void AddToInventory(Item item)
    {
        //Todo
        inventory.Add(item);
    }

    // remove an item from the inventory list
    public void RemoveFromInventory(Item item)
    {
        //Todo
        inventory.Remove(item);
    }

    // remove an item from the inventory list and replace the equipment in the slot at the moment
    public void Equip(Equipment item)
    {
        //Todo
        int slot = (int)item.GetEquipSlot();

        if(equipment[slot] != null)
        {
            AddToInventory(equipment[slot]);
        }
        equipment[slot] = item;
        RemoveFromInventory(item);
    }

    // remove the specified equipment from the equipment slot and add it to the inventory
    public void UnEquip(EquipSlot equipSlot)
    {
        //Todo
        int slot = (int)equipSlot;
        if (equipment[slot] != null) equipment[slot] = null;
    }
}

public enum EquipSlot
{
    head,
    chest,
    feet,
    leftHand,
    rightHand
}
