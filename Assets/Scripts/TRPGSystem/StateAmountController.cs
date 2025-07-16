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
        Debug.Log("Enter Minus");
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
    
    private void CheckMinus(int stateID, int value)
    {
        Debug.Log("Enter CheckMinus");
        if (stateScores[stateID] == 0)
        {
            Debug.Log("최솟값 미만으로 설정 불가");
            return;
        }

        if (stateScores[stateID] < value)
        {
            Minus(stateID, stateScores[stateID]);
            return;
        }

        Minus(stateID, value);
    }

    private void CheckPlus(int stateID, int value)
    {
        if (remainingAmount == 0)
        {
            Debug.Log("남은 포인트 없음");
            return;
        }

        if (remainingAmount < value)
        {
            if(stateScores[stateID] == 100)
            {
                Debug.Log("최댓값 초과로 설정 불가");
                return;
            }

            if (stateScores[stateID] + remainingAmount > 100)
            {
                value = 100 - stateScores[stateID];
                Plus(stateID, value);
                return;
            }

            Plus(stateID, remainingAmount);
            return;
        }

        if (stateScores[stateID] +  value > 100)
        {
            value = 100 - stateScores[stateID];
        }

        Plus(stateID, value);
    }

    public void OnMinusOneClicked()
    {
        CheckMinus(ButtonParent(), 1);
    }

    public void OnMinusTenClicked()
    {
        CheckMinus(ButtonParent(), 10);
    }

    public void OnPlusOneClicked()
    {
        CheckPlus(ButtonParent(), 1);
    }

    public void OnPlusTenClicked()
    {
        CheckPlus(ButtonParent(), 10);
    }

    private int ButtonParent()
    {
        return (int)Enum.Parse(typeof(StateEnum), EventSystem.current.currentSelectedGameObject.transform.parent.name);
    }
}