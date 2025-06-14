using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Location currentLocation;

    public List<Item> inventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeLocation(GameController controller, string noun)
    {
        Connection connection = currentLocation.GetConnection(noun);

        if (connection != null)
        {
            if(connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller, Location destination)
    {
        currentLocation = destination;
        controller.DisplayLocation();
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        // checks if the item doesn't require a specific target.
        if (item.targetItem == null) return true;

        // checks whether the player holds the target item in their inventory.
        if (HasItem(item.targetItem)) return true;

        // checks whether the target item is in their current location.
        if (currentLocation.HasItem(item.targetItem))
            return true;
        
        return false;
    }

    internal bool CanReadItem(GameController controller, Item item)
    {
        if(item.playerCanRead) return true;
        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach(Item item in inventory)
        {
            if(item == itemToCheck && item.itemEnabled) return true;
        }
        return false;
    }

    public bool HasItemByName(string noun)
    {
        foreach(Item item in inventory)
        {
            if(item.itemName.ToLower() == noun) return true;
        }
        return false;
    }

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        if (item.playerCanTalkTo) return true;
        return false;
    }

    internal bool CanGiveToItem(GameController controller, Item item)
    {
        if (item.playerCanGiveTo) return true;
        return false;
    }
}
