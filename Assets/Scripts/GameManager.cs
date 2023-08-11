using TMPro;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public ScriptableDifficulties ScriptableDifficultiesGm { get; set; }

    public static GameManager Instance;

    public int finalScore;
    public GameObject DifficultyPanel;
    public GameObject ScorePanel;
    public TMP_Text scoreText;
    
    
    private Coroutine _coroutine;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetScriptableDifficulty(ScriptableDifficulties scriptableDifficulties)
    {
        ScriptableDifficultiesGm = scriptableDifficulties;
        DifficultyPanel.SetActive(false);
        ScorePanel.SetActive(true);
        
        finalScore = 0;
        scoreText.text = "Score: " + finalScore.ToString();
    }

    public void ChangeScore(int amount)
    {
        finalScore += amount;
        scoreText.text = "Score: " + finalScore.ToString();
    }

    public void SpawnItems()
    {
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
    IEnumerator WaitForSpawns()
    {
        int waitingTime = Random.Range(ScriptableDifficultiesGm.minimumTimeBetweenSpawns,
            ScriptableDifficultiesGm.maximumTimeBetweenSpawns);
        yield return new WaitForSeconds(waitingTime);
        SpawnItems();
    }
}