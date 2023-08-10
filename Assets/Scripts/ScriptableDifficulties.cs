using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty")]
public class ScriptableDifficulties : ScriptableObject
{
    [System.Serializable]
    public class ItemChance
    {
        public string tag;
        public ScriptableItem scriptableItem;
        public int spawnChance;
    }

    public List<ItemChance> itemChances; 

    public int minimumTimeBetweenSpawns;
    public int maximumTimeBetweenSpawns;

    public int minimumObjectsAtTheSameTime;
    public int maximumObjectsAtTheSameTime;
}
