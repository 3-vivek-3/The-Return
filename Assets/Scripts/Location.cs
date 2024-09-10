using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach (Connection c in connections)
        {
            if (c.connectionEnabled) result += c.description + "\n";
        }
        return result;
    }

    public Connection GetConnection(string noun)
    {
        foreach(Connection c in connections)
        {
            if (c.connectionName.ToLower() == noun.ToLower()) return c;
        }
        return null;
    }

    public string GetItemsText()
    {
        if (items.Count == 0) return "";

        string result = "You see:\n";
        foreach (Item item in items)
        {
            if(item.itemEnabled) result += item.description + "\n";
        }
        return result;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach(Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled) return true;
        }
        return false;
    }

    public void ModifyDescription(string description)
    {
        this.description = description;
    }
}
