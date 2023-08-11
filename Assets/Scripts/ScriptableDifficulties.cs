using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty")]
public class ScriptableDifficulties : ScriptableObject
{
    public string difficulty;
    
    [System.Serializable]
    public class ItemChance
    {
        public string tag;
        public ScriptableItem scriptableItem;
        [Range(0,100)]
        public int spawnChance;
    }

    public List<ItemChance> itemChances; 

    public int minimumTimeBetweenSpawns;
    public int maximumTimeBetweenSpawns;

    // public int minimumObjectsAtTheSameTime;
    // public int maximumObjectsAtTheSameTime;
    
    [Space]
    public int totalChanceOfAllItems;
}
