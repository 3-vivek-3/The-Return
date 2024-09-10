using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Here")]
public class Here : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.DisplayLocation();
    }
}
