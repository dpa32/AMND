using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateRoll : MonoBehaviour
{
    public bool IsSuccess;
    public bool IsRolling;
    public bool IsProgress;
    public bool IsIdle = true;

    [SerializeField]
    private GameObject states;
    private int[] stateScores;

    [SerializeField]
    private Image diceImagePrefab;
    [SerializeField]
    private List<Sprite> diceSpritesVer1;
    [SerializeField]
    private List<Sprite> diceSpritesVer2;

    private float duration = 3f;
    private float fastDelay = 0.05f;
    private float slowDelay = 0.7f;

    private Coroutine rollingDiceCoroutine;

    private const int length = 10;
    private int result = 0;
    private int stateID = 0;

    void Start()
    {
        stateScores = states.GetComponent<StateAmountController>().StateScores();
        IsIdle = true;
    }

    public void RollingDice(int sID) // t:성공, f:실패
    {
        result = 0;
        IsProgress = true;
        IsIdle = false;
        diceImagePrefab.gameObject.SetActive(true);

        StartRolling(true);

        stateID = sID;
    }

    private void StartRolling(bool diceVer)
    {
        if (rollingDiceCoroutine != null)
        {
            StopCoroutine(rollingDiceCoroutine);
        }
        rollingDiceCoroutine = StartCoroutine(Roll(diceVer));
    }

    IEnumerator Roll(bool diceVer)
    {
        float time = 0f;
        List<Sprite> sprites = diceVer ? diceSpritesVer2 : diceSpritesVer1;

        int random = Random.Range(0, length);
        result += diceVer ? (random+1) * 10 : random;
        Sprite resultSprite = sprites[random];

        while (time < duration)
        {
            float t = time / duration;
            float delay = Mathf.Lerp(fastDelay, slowDelay, t);

            Sprite sprite = sprites[Random.Range(0, length)];
            diceImagePrefab.sprite = sprite;

            yield return new WaitForSeconds(delay);
            time += delay;
        }

        diceImagePrefab.sprite = resultSprite;
        yield return new WaitForSeconds(1f);

        rollingDiceCoroutine = null;
        IsRolling = false;

        if (diceVer && result != 100)
        {
            StartRolling(false);
        }
        else
        {
            diceImagePrefab.gameObject.SetActive(false);
            IsSuccess = stateScores[stateID] >= result;
            IsProgress = false;
        }
    }
}
