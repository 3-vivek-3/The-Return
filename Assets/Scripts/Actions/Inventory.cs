using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (controller.player.inventory.Count == 0) controller.currentText.text = "You have nothing...\n\n";
        else
        {
            string result = "You have: \n";
            foreach(Item item in controller.player.inventory)
            {
                result += "<color=#FFD700>" + item.itemName.ToLower() + "</color>\n";
            }
            controller.currentText.text = result + "\n";
        }
    }
}
