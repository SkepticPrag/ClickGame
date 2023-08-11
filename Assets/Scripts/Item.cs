using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Item : MonoBehaviour, IItem
{
    public int ClicksNeeded { get; set; }
    public int ItemAddScore { get; set; }
    public int ItemPointLoss { get; set; }
    public int ItemLifeSpan { get; set; }

    private Coroutine _coroutine;

    public void OnItemSpawn(bool isActive, Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(isActive);
        transform.position = position;
        transform.rotation = rotation;

        _coroutine = StartCoroutine(DespawnItem());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public IEnumerator DespawnItem()
    {
        yield return new WaitForSeconds(ItemLifeSpan);
        Debug.Log("Point loss: " + ItemPointLoss);
        gameObject.SetActive(false);
    }

    public abstract void OnPointerClick(PointerEventData eventData);
}