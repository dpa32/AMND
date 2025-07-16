using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Chat
{
    public string Name;
    public string Text;

    public int LeftCharacter;
    public int LeftFace;

    public int RightCharacter;
    public int RightFace;

    public Chat(int leftCharacter, int leftFace, int rightCharacter, int rightFace, string name, string text)
    {
        Name = name;
        Text = text;

        LeftCharacter = leftCharacter;
        LeftFace = leftFace;
        RightCharacter = rightCharacter;
        RightFace = rightFace;
    }
}

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream

public class Dialogue
=======
public class Dialogue : MonoBehaviour
>>>>>>> Stashed changes
=======
public class Dialogue : MonoBehaviour
>>>>>>> Stashed changes
=======
public class Dialogue : MonoBehaviour
>>>>>>> Stashed changes
=======
public class Dialogue : MonoBehaviour
>>>>>>> Stashed changes
{
    public string SuceessScript;
    public int SuccessScore;

    public string FailScript;
    public int FailScore;

    public bool IsRoll;

    public List<Chat> Chats;

    public Dialogue(string sScript, int sScore, string fScript, int fScore, bool isRoll, List<Chat> chats)
    {
        SuceessScript = sScript;
        SuccessScore = sScore;
        FailScript = fScript;
        FailScore = fScore;
        IsRoll = isRoll;

        Chats = chats;
    }
}
