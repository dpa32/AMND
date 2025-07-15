using UnityEngine;
using UnityEngine.EventSystems;

public class ControllStateAmountm
{
    private int remainingAmount = 500;

    private void MinusRemains(int count)
    {

    }

    private void PlusRemins(int count)
    {

    }

    public void OnMinusOneClicked()
    {

    }

    public void OnMinusTenClicked()
    {

    }

    public void OnPlusOneClicked()
    {

    }

    public void OnPlusTenClicked()
    {
        
    }

    private GameObject ButtonParent()
    {
        return EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
    }
}