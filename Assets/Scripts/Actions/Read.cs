using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // read items in room
        if (ReadItems(controller, controller.player.currentLocation.items, noun)) return;

        // read items in inventory
        if (ReadItems(controller, controller.player.inventory, noun)) return;

        controller.currentText.text = "There is no " + noun.ToLower() + "...\n\n";
    }

    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if(item.name.ToLower() == noun)
            {
                if(controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read")) return true;
                }
                controller.currentText.text = "The " + item.itemName + " has nothing to read...\n\n";
                return true;
            }
        }
        return false;
    }
}
