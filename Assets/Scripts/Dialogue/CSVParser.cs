using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSVParser : MonoBehaviour
{
    public Dialogue ParseDialog(string csvName)
    {
        if (csvName == "finish")
        {
            StartCoroutine(WaitSec());
            SceneManager.LoadScene("MainScene");
            return null;
        }

        List<Chat> chats = new List<Chat>();
        TextAsset csvText = Resources.Load<TextAsset>(csvName);

        string[] textData = csvText.text.Split('\n');

        for (int line = 1; line < textData.Length; line++)
        {
            string[] lineData = textData[line].Split('/');

            if(lineData.Length != 4)
            {
                Debug.LogError($"Line{line} : {textData[line]}");
                Debug.Break();
            }
            else
            {
                Chat chat = new Chat(
                    Int32.Parse(lineData[0]),
                    Int32.Parse(lineData[1]),
                    lineData[2],
                    lineData[3]
                    );

                chats.Add(chat);
            }
        }

        string[] typeData = textData[0].Split('/');

        Dialogue dialogue = new Dialogue(
            typeData[0],
            Int32.Parse(typeData[1]),
            typeData[2],
            Int32.Parse(typeData[3]),
            (StateEnum)int.Parse(typeData[4]),
            Int32.Parse(typeData[5]), 
            Boolean.Parse(typeData[6]),
            chats
            );

        return dialogue;
    }

    IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(2f);
    }
}