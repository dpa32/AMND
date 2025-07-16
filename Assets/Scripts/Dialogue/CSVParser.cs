using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CSVParser : MonoBehaviour
{
    public Dialogue ParseDialog(string csvName)
    {
        List<Chat> chats = new List<Chat>();
        TextAsset csvText = Resources.Load<TextAsset>(csvName);

        string[] textData = csvText.text.Split('\n');

        for (int line = 1; line < textData.Length; line++)
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            string[] lineData = textData[line].Split('/');
=======
            string[] lineData = textData[line].Split(',');
>>>>>>> Stashed changes
=======
            string[] lineData = textData[line].Split(',');
>>>>>>> Stashed changes
=======
            string[] lineData = textData[line].Split(',');
>>>>>>> Stashed changes
=======
            string[] lineData = textData[line].Split(',');
>>>>>>> Stashed changes

            Chat chat = new Chat(
                Int32.Parse(lineData[0]),
                Int32.Parse(lineData[1]),
                Int32.Parse(lineData[2]),
                Int32.Parse(lineData[3]),
                lineData[4],
                lineData[5]
                );

            chats.Add(chat);
        }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        string[] typeData = textData[0].Split('/');
=======
        string[] typeData = textData[0].Split(',');
>>>>>>> Stashed changes
=======
        string[] typeData = textData[0].Split(',');
>>>>>>> Stashed changes
=======
        string[] typeData = textData[0].Split(',');
>>>>>>> Stashed changes
=======
        string[] typeData = textData[0].Split(',');
>>>>>>> Stashed changes

        Dialogue dialogue = new Dialogue(
            typeData[0],
            Int32.Parse(typeData[1]),
            typeData[2],
            Int32.Parse(typeData[3]),
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            Boolean.Parse(typeData[4]),
            chats
            );

        Debug.Log(dialogue);

=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            Boolean.Parse(typeData[5]),
            chats
            );

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        return dialogue;
    }
}
