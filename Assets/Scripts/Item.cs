using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IItem
{
    public ScriptableItem item;
    private GameObject _prefabToSpawn;

    public void SpawnItem()
    {
        _prefabToSpawn = Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
    }

    public void DespawnItem()
    {
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("HolaMundo");
    }
}