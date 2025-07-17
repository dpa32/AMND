using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Chat
{
    public string Name;
    public string Text;

    public int LeftCharacter;
    public int RightCharacter;

    public Chat(int leftCharacter, int rightCharacter, string name, string text)
    {
        Name = name;
        Text = text;

        LeftCharacter = leftCharacter;
        RightCharacter = rightCharacter;
    }
}

public class Dialogue
{
    public string SuceessScript;
    public int SuccessScore;

    public string FailScript;
    public int FailScore;

    public bool IsRoll;

    public StateEnum State;

    public int Background;

    public List<Chat> Chats;

    public Dialogue(string sScript, int sScore, string fScript, int fScore, StateEnum state, int background, bool isRoll, List<Chat> chats)
    {
        SuceessScript = sScript;
        SuccessScore = sScore;
        FailScript = fScript;
        FailScore = fScore;
        State = state;
        Background = background;
        IsRoll = isRoll;

        Chats = chats;
    }
}
