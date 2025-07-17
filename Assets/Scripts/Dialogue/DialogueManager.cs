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


    private int chatIndex = 0;
    private bool isProgress = true;
    private bool isTyping;

    private void Start()
    {
        gameData = DataManager.Instance.gameData;
        CSV = GetComponent<CSVParser>();

        SetDialogue("1_x");
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
        if (dialogue != null && roll.IsRolling == false)
        {
            if (chatIndex < dialogue.Chats.Count)
            {
                StopAllCoroutines();
                PresentDialogue();
                isTyping = false;
            }
            else if(isTyping == false)
            {
                if (dialogue.IsRoll)
                {
                    Debug.Log($"{roll.IsIdle} {roll.IsProgress}");
                    if (roll.IsIdle)
                    {
                        roll.RollingDice((Int32)dialogue.State);
                    }
                    else if(!roll.IsIdle && !roll.IsProgress)
                    {
                        chatIndex = 0;

                        SetDialogue(roll.IsSuccess ? dialogue.SuceessScript : dialogue.FailScript);
                        PresentDialogue();

                        roll.IsIdle = true;
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
        Debug.Log(chatIndex);
        leftCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].LeftCharacter];
        rightCharacter.sprite = characterSprite[dialogue.Chats[chatIndex].RightCharacter];
        background.sprite = backgroundSprite[dialogue.Background];
        nameText.text = dialogue.Chats[chatIndex].Name;
        StartCoroutine(typing(dialogue.Chats[chatIndex].Text));

        chatIndex++;
    }

    private IEnumerator typing(string chat)
    {
        isTyping = true;
        chatText.text = " ";
        for (int i = 0; i < chat.Length; i++)
        {
            chatText.text += chat[i];
            yield return new WaitForSeconds(0.03f);


        }
        isTyping = false;
    }
}
