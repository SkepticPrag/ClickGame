using TMPro;
using UnityEngine;

public class DifficultyDisplay : MonoBehaviour
{
    [SerializeField] private ScriptableDifficulties scriptableDifficulties;

    public TMP_Text difficultyText;

    private void Start()
    {
        difficultyText.text = scriptableDifficulties.difficulty;
    }
}