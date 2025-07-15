using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateRoll : MonoBehaviour
{
    [SerializeField]
    private GameObject states;
    private int[] stateScores;

    [SerializeField]
    private Image diceImage;
    [SerializeField]
    private List<Sprite> diceSpritesVer1;
    [SerializeField]
    private List<Sprite> diceSpritesVer2;

    private float duration = 2f;
    private float fastDelay = 0.05f;
    private float slowDelay = 0.5f;

    private Coroutine rollingDiceCoroutine;
    private Image image;

    private const int length = 10;
    private int result;

    void Start()
    {
        stateScores = states.GetComponent<StateAmountController>().StateScores();

        RollingDice(Random.Range(0,8)); // 랜덤 대신 원하는 stateID 넣음 됨
    }

    private bool RollingDice(int stateID) // t:성공, f:실패
    {
        StartRolling(true);
        Debug.Log($"{result} {stateID}");
        if (result != 100)
        {
            StartRolling(false);
            Debug.Log(result);
        }

        bool isSuc = stateScores[stateID] >= result;
        Debug.Log($"{stateID} {isSuc}");
        result = 0;

        return isSuc;
    }

    private void StartRolling(bool diceVer)
    {
        image = Instantiate(diceImage);
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

        result += diceVer ? random * 10 : random;
        Sprite resultSprite = sprites[random];

        while (time < duration)
        {
            float t = time / duration;
            float delay = Mathf.Lerp(fastDelay, slowDelay, t);

            Sprite sprite = sprites[Random.Range(0, length)];
            image.sprite = sprite;

            yield return new WaitForSeconds(delay);
            time += delay;
        }

        diceImage.sprite = resultSprite;
        yield return new WaitForSeconds(1f);

        rollingDiceCoroutine = null;
    }
}
