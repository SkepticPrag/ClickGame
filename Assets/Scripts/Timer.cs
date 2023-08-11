using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public int countdownTimer;

    private Coroutine coroutine;

    public void BeginCountdown()
    {
        coroutine = StartCoroutine(CountdownToFinish());
    }

    private void OnDisable()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    private IEnumerator CountdownToFinish()
    {
        while (countdownTimer > 0)
        {
            timerText.text = countdownTimer.ToString();

            yield return new WaitForSeconds(1f);

            countdownTimer--;
        }

        GameManager.Instance.LoseState();

        timerText.text = "GAME OVER";

        yield return new WaitForSeconds(3f);
    }
}