using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemPickup : Interactable
{
    Item item;
    SpriteRenderer sr;

    void Awake()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.pickupIcon;
        // set this object's sprite to the world object sprite from item
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Picking up Item: " + item.GetItemName());
        GameController.instance.AddToInventory(item); // Add item to the inventory
        Destroy(gameObject, 0);                       // Remove the pickup item from the world
    }
}
