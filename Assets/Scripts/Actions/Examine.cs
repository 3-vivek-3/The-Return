using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // examine items in room
        if (ExamineItems(controller, controller.player.currentLocation.items, noun)) return;

        // examin items in inventory
        if (ExamineItems(controller, controller.player.inventory, noun)) return;

        controller.currentText.text = "You can't see a " + noun.ToLower() + "...\n\n";
    }

    private bool ExamineItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun && item.itemEnabled)
            {
                if (item.InteractWith(controller, "examine")) return true;
                controller.currentText.text = "You see " + item.description.ToLower() + "\n\n";
                return true;
            }
        }
        return false;
    }
}
