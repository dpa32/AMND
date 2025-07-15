using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;
using System.Threading;

public class StateAmountController : MonoBehaviour
{
    private const int length = 8;

    [SerializeField]
    private TextMeshProUGUI remains;
    [SerializeField] 
    private TextMeshProUGUI[] stateScoresUI;
    private int[] stateScores = Enumerable.Repeat(50, length).ToArray();
    private int remainingAmount = 100;

    public int[] StateScores() => stateScores;

    private void Start()
    {
        remains.text = "100";
        for (int i = 0; i < length; i++)
        {
            stateScoresUI[i].text = "50";
        }
    }

    private void Minus(int stateID, int value)
    {
        remainingAmount += value;
        remains.text = remainingAmount.ToString();
        stateScores[stateID] -= value;
        stateScoresUI[stateID].text = stateScores[stateID].ToString();
    }

    private void Plus(int stateID, int value)
    {
        remainingAmount -= value;
        remains.text = remainingAmount.ToString();
        stateScores[stateID] += value;
        stateScoresUI[stateID].text = stateScores[stateID].ToString();
    }


    public void OnMinusOneClicked()
    {
        Minus(ButtonParent(), 1);
    }

    public void OnMinusTenClicked()
    {
        Minus(ButtonParent(), 10);
    }

    public void OnPlusOneClicked()
    {
        Plus(ButtonParent(), 1);
    }

    public void OnPlusTenClicked()
    {
        Plus(ButtonParent(), 10);
    }

    private int ButtonParent()
    {
        return (int)Enum.Parse(typeof(StateEnum), EventSystem.current.currentSelectedGameObject.transform.parent.name);
    }
}