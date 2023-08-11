using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public ScriptableDifficulties ScriptableDifficultiesGm { get; set; }

    public static GameManager Instance;

    public int finalScore;
    [SerializeField] private GameObject difficultyPanel;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject timerPanel;
    [SerializeField] private TMP_Text scoreText;

    private List<string> _auxList;
    private int _auxHoarder;
    private string _itemToSpawnTag;

    private Timer _timer;

    private float _distFromCamera = 10.0f;
    
    private Coroutine _coroutine;

    private Vector3 _pos;


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

    private void Start()
    {
        _auxHoarder = 0;
        _auxList = new List<string>();
    }

    public void SetScriptableDifficulty(ScriptableDifficulties scriptableDifficulties)
    {
        ScriptableDifficultiesGm = scriptableDifficulties;
        _timer = GetComponent<Timer>();
        difficultyPanel.SetActive(false);
        scorePanel.SetActive(true);
        timerPanel.SetActive(true);

        finalScore = 0;
        scoreText.text = "Score: " + finalScore.ToString();

        for (int i = 0; i < ScriptableDifficultiesGm.itemChances.Count; i++)
        {
            _auxHoarder = ScriptableDifficultiesGm.itemChances[i].spawnChance;

            for (int j = 0; j < _auxHoarder; j++)
            {
                _auxList.Add(ScriptableDifficultiesGm.itemChances[i].tag);
            }
        }

        _timer.BeginCountdown();
        SpawnItems();
    }

    public void ChangeScore(int amount)
    {
        finalScore += amount;
        scoreText.text = "Score: " + finalScore.ToString();

        if (finalScore >= 100)
            WinState();
    }

    private void SpawnItems()
    {
        int randomChance = Random.Range(0, 100);

        _itemToSpawnTag = _auxList[randomChance];

        _pos = new Vector3(Random.value, Random.value, _distFromCamera);
        _pos = Camera.main.ViewportToWorldPoint(_pos);
        
        _coroutine = StartCoroutine(WaitForSpawns());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    IEnumerator WaitForSpawns()
    {
        int waitingTime = Random.Range(ScriptableDifficultiesGm.minimumTimeBetweenSpawns,
            ScriptableDifficultiesGm.maximumTimeBetweenSpawns + 1);

        yield return new WaitForSeconds(waitingTime);

        ObjectPooler.Instance.SpawnFromPool(_itemToSpawnTag, _pos, Quaternion.identity);

        SpawnItems();
    }

    public void LoseState()
    {
        StopAllCoroutines();
        ObjectPooler.Instance.DespawnObjects();
        scoreText.text = "YOU LOSE";
    }

    public void WinState()
    {
        StopAllCoroutines();
        _timer.StopAllCoroutines();
        ObjectPooler.Instance.DespawnObjects();
        scoreText.text = "YOU WIN!";
    }
}