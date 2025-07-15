using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Sprite[][] characterSprite;// = new Sprite[11, 3];

    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image RightCharacter;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text chatText;

    private Dialogue dialogue;
    private CSVParser CSV;

    private int chatIndex;
    private bool isProgress;

    private void Start()
    {
        CSV = GetComponent<CSVParser>();
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
        if (isProgress)
        {
            if (chatIndex < dialogue.Chats.Count)
            {
                leftCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].LeftCharacter][dialogue.Chats[chatIndex].LeftFace];
                RightCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].RightCharacter][dialogue.Chats[chatIndex].RightFace];
                nameText.text = dialogue.Chats[chatIndex].Name;
                chatText.text = dialogue.Chats[chatIndex].Text;

                chatIndex++;
            }
            else
            {
                chatIndex = 0;

                if (dialogue.IsRoll)
                {
                    //롤 굴려주세요
                }
                else
                {
                    SetDialogue(dialogue.SuceessScript);
                }
            }
        }

    }

    private void SetDialogue(string scrpitName)
    {
        dialogue = CSV.ParseDialog(scrpitName);
    }
}