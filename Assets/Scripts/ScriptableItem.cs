using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ScriptableItem : ScriptableObject
{
    public string itemName;

    public GameObject itemPrefab;
    public int lifeSpan = 5;
    
    public int clickedScore;
    public int pointLoss;
    
}
