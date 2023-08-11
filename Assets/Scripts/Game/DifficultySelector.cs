using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class DifficultySelector : MonoBehaviour
    {
        [SerializeField] private ScriptableDifficulties difficulty;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SetDifficulty);
        }

        private void SetDifficulty()
        {
            GameManager.Instance.SetScriptableDifficulty(difficulty);
        }
    
    }
}
