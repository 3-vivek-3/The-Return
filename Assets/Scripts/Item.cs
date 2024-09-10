using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;

    public bool itemEnabled = true;

    public Item targetItem = null;

    public bool playerCanTalkTo = false;

    public bool playerCanGiveTo = false;

    public bool playerCanUse = false;

    public bool playerCanRead = false;

    public Interaction[] interactions;

    public bool InteractWith(GameController controller, string actionKeyword, string noun = "")
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword.ToLower() == actionKeyword.ToLower())
            {
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower()) continue;
                foreach(Item disableItem in interaction.itemsToDisable) disableItem.itemEnabled = false;
                foreach(Item enableItem in interaction.itemsToEnable) enableItem.itemEnabled = true;
                foreach(Connection disConnection in interaction.connectionsToDisable) disConnection.connectionEnabled = false;
                foreach(Connection enConnection in interaction.connectionsToEnable) enConnection.connectionEnabled = true;

                if(interaction.descriptionToModify.Trim() != "")
                    controller.player.currentLocation.ModifyDescription(interaction.descriptionToModify);

                if (interaction.teleportLocation != null) controller.player.Teleport(controller, interaction.teleportLocation);
                else controller.currentText.text = interaction.response + "\n\n";

                return true;
            }
        }
        return false;
    }


}
