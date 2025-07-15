using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

<<<<<<< Updated upstream
[System.Serializable]
public class CharacterSprite
{
    public Sprite[] Face;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private CharacterSprite[] characterSprite;
=======
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Sprite[][] characterSprite;// = new Sprite[11, 3];
>>>>>>> Stashed changes

    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image RightCharacter;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text chatText;

    private Dialogue dialogue;
<<<<<<< Updated upstream
    private GameData gameData;
    private CSVParser CSV;


    private int chatIndex;
    private bool isProgress = true;

    private void Start()
    {
        gameData = DataManager.Instance.gameData;
        CSV = GetComponent<CSVParser>();

        SetDialogue("test");
=======
    private CSVParser CSV;

    private int chatIndex;
    private bool isProgress;

    private void Start()
    {
        CSV = GetComponent<CSVParser>();
>>>>>>> Stashed changes
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextChat();
        }
    }

    public void NextChat()
    {
<<<<<<< Updated upstream
        if (isProgress && dialogue != null)
        {
            if (chatIndex < dialogue.Chats.Count)
            {
                leftCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].LeftCharacter].Face[dialogue.Chats[chatIndex].LeftFace];
                RightCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].RightCharacter].Face[dialogue.Chats[chatIndex].RightFace];
=======
        if (isProgress)
        {
            if (chatIndex < dialogue.Chats.Count)
            {
                leftCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].LeftCharacter][dialogue.Chats[chatIndex].LeftFace];
                RightCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].RightCharacter][dialogue.Chats[chatIndex].RightFace];
>>>>>>> Stashed changes
                nameText.text = dialogue.Chats[chatIndex].Name;
                chatText.text = dialogue.Chats[chatIndex].Text;

                chatIndex++;
            }
            else
            {
                chatIndex = 0;
<<<<<<< Updated upstream
                isProgress = false;
=======
>>>>>>> Stashed changes

                if (dialogue.IsRoll)
                {
                    //롤 굴려주세요
                }
                else
                {
                    SetDialogue(dialogue.SuceessScript);
<<<<<<< Updated upstream
                    gameData.PlayingScript = dialogue.SuceessScript;
=======
>>>>>>> Stashed changes
                }
            }
        }

    }
<<<<<<< Updated upstream
    public void SetDialogue(string scrpitName)
    {
        dialogue = CSV.ParseDialog(scrpitName);

        isProgress = true;
=======

    private void SetDialogue(string scrpitName)
    {
        dialogue = CSV.ParseDialog(scrpitName);
>>>>>>> Stashed changes
    }
}