using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
[System.Serializable]

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Sprite[] characterSprite;
    [SerializeField] private Sprite[] backgroundSprite;
    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image rightCharacter;
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text chatText;
    [SerializeField] private StateRoll roll;

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
        PresentDialogue();
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
                PresentDialogue();
            }
            else
            {
                chatIndex = 0;
                isProgress = false;

                if (dialogue.IsRoll)
                {
                    if (roll.RollingDice((Int32)dialogue.State)) //����
                    {
                        SetDialogue(dialogue.SuceessScript);
                        PresentDialogue();
                    }
                    else //����
                    {
                        SetDialogue(dialogue.FailScript);
                        PresentDialogue();
                    }
                }
                else
                {
                    SetDialogue(dialogue.SuceessScript);
                    PresentDialogue();
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

    public void PresentDialogue()
    { 
        leftCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].LeftCharacter];
        rightCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].RightCharacter];
        background.sprite = backgroundSprite[dialogue.Background];
        nameText.text = dialogue.Chats[chatIndex].Name;
        chatText.text = dialogue.Chats[chatIndex].Text;

        chatIndex++;
    }
}
