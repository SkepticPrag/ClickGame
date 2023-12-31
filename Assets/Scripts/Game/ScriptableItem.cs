using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New Item")]
    public class ScriptableItem : ScriptableObject
    {
        public string itemName;

        public GameObject itemPrefab;
        public int lifeSpan = 5;

        public int clicksNeeded;
        public int clickedScore;
        public int pointLoss;
    }
}