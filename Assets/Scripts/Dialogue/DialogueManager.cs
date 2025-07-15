using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class CharacterSprite
{
    public Sprite[] Face;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private CharacterSprite[] characterSprite;

    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image RightCharacter;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text chatText;

    private Dialogue dialogue;
    private GameData gameData;
    private CSVParser CSV;


    private int chatIndex;
    private bool isProgress = true;

    private void Start()
    {
        gameData = DataManager.Instance.gameData;
        CSV = GetComponent<CSVParser>();

        SetDialogue("test");
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
        if (isProgress && dialogue != null)
        {
            if (chatIndex < dialogue.Chats.Count)
            {
                leftCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].LeftCharacter].Face[dialogue.Chats[chatIndex].LeftFace];
                RightCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].RightCharacter].Face[dialogue.Chats[chatIndex].RightFace];
                nameText.text = dialogue.Chats[chatIndex].Name;
                chatText.text = dialogue.Chats[chatIndex].Text;

                chatIndex++;
            }
            else
            {
                chatIndex = 0;
                isProgress = false;

                if (dialogue.IsRoll)
                {
                    //롤 굴려주세요
                }
                else
                {
                    SetDialogue(dialogue.SuceessScript);
                    gameData.PlayingScript = dialogue.SuceessScript;
                }
            }
        }

    }
    public void SetDialogue(string scrpitName)
    {
        dialogue = CSV.ParseDialog(scrpitName);

        isProgress = true;
    }
}