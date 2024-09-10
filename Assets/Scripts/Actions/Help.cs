using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.currentText.text = "Type a verb followed by a noun (e.g. \"go north\").\n";
        controller.currentText.text = "Allowed verbs: \nexamine, give, go, help, here, inventory, take, read, say, talkto, use.\n\n";
    }
}
