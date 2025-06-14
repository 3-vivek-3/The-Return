using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TalkTo")]
public class TalkTo : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (TalkToItem(controller, controller.player.currentLocation.items, noun)) return;

        controller.currentText.text = "There is no " + noun + "...\n\n";
    }

    private bool TalkToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower() && item.itemEnabled)
            {
                if (controller.player.CanTalkToItem(controller, item))
                {
                    if (item.InteractWith(controller, "talkto")) return true;
                }
                controller.currentText.text = "The " + item.itemName.ToLower() + " doesn't respond...\n\n";
                return true;
            }
        }
        return false;
    }
}
