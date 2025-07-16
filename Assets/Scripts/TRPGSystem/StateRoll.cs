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
    private Image diceImagePrefab;
    [SerializeField]
    private List<Sprite> diceSpritesVer1;
    [SerializeField]
    private List<Sprite> diceSpritesVer2;

    private float duration = 3f;
    private float fastDelay = 0.05f;
    private float slowDelay = 0.7f;

    private Coroutine rollingDiceCoroutine;
    private Image image;

    private const int length = 10;
    private int result = 0;

    void Start()
    {
        stateScores = states.GetComponent<StateAmountController>().StateScores();

    }

    public bool RollingDice(int stateID) // t:성공, f:실패
    {
        result = 0;

        StartRolling(true);

        bool isSuc = stateScores[stateID] >= result;

        return isSuc;
    }

    private void StartRolling(bool diceVer)
    {
        image = Instantiate(diceImagePrefab, this.transform);
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
        Debug.Log($"{diceVer} {random} {result}");
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

        image.sprite = resultSprite;
        yield return new WaitForSeconds(3f);

        rollingDiceCoroutine = null;
        if (diceVer && result != 100) StartRolling(false);
    }
}
