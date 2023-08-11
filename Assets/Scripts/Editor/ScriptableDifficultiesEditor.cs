using Game;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ScriptableDifficulties))]
    public class ScriptableDifficultiesEditor : UnityEditor.Editor
    {
        private ScriptableDifficulties _scriptableDifficulties;
        private SerializedObject _getTarget;
        private SerializedProperty _itemChancesLists;
        private SerializedProperty _itemChance;
        private SerializedProperty _totalChance;
        private int _auxTotalAmount;
        private int _limit;

        private void OnEnable()
        {
            _scriptableDifficulties = (ScriptableDifficulties)target;
            _getTarget = new SerializedObject(_scriptableDifficulties);
            _itemChancesLists = _getTarget.FindProperty("itemChances");
            _totalChance = _getTarget.FindProperty("totalChanceOfAllItems");
        }

        public override void OnInspectorGUI()
        {
            _getTarget.Update();

            base.OnInspectorGUI();

            _auxTotalAmount = 0;

            _limit = 0;

            for (int i = 0; i < _itemChancesLists.arraySize; i++)
            {
                if (i > _itemChancesLists.arraySize) return;
                _itemChance = _itemChancesLists.GetArrayElementAtIndex(i).FindPropertyRelative("spawnChance");
                _auxTotalAmount += _itemChance.intValue;
            }

            for (int i = 0; i < _itemChancesLists.arraySize; i++)
            {
                _itemChance = _itemChancesLists.GetArrayElementAtIndex(i).FindPropertyRelative("spawnChance");

                _limit = 100 - _auxTotalAmount + _itemChance.intValue;

                if (i < _scriptableDifficulties.itemChances.Count)
                    _scriptableDifficulties.itemChances[i].spawnChance =
                        Mathf.Clamp(_scriptableDifficulties.itemChances[i].spawnChance, 0, _limit);
            }

            _totalChance.intValue = _auxTotalAmount;
            _totalChance.intValue = Mathf.Clamp(_totalChance.intValue, 0, 100);

            _scriptableDifficulties.totalChanceOfAllItems = _totalChance.intValue;

            serializedObject.ApplyModifiedProperties();
        }
    }
}