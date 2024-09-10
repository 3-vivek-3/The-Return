using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public TMP_Text logText;
    public TMP_Text currentText;
    public TMP_InputField textEntryField;

    public Action[] actions;

    [TextArea]
    public string introText;

    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to make current text display player location and available connections
    public void DisplayLocation()
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText() + "\n";
        if (player.currentLocation.items.Count > 0) description += player.currentLocation.GetItemsText() + "\n";
        currentText.text = description;
    }

    // event that's triggered on pressing return after typing in input field.
    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    // Function that moves current text to history text, along with user input.
    void LogCurrentText()
    {
        // Moving the current text to history
        logText.text += "\n";
        logText.text += currentText.text;

        // Adding the entry in input field with different colour
        logText.text += "<color=#00FF2A>" + textEntryField.text + "</color>\n";

    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = {' '};
        string[] separatedWords = input.Split(delimiter);

        foreach(Action action in actions)
        {
            // checks if verb matches any action's keyword.
            if (action.keyword.ToLower() == separatedWords[0])
            {
                // input has more than one word.
                if (separatedWords.Length > 1) action.RespondToInput(this, separatedWords[1]);
                // input has one word.
                else action.RespondToInput(this, "");
                return;
            }
        }

        currentText.text = "Nothing happens...\n\n";

    }
}
