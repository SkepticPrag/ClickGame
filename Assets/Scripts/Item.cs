using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IItem
{
    private int _itemAddScore;
    private int _itemPointLoss;
    private int _itemLifeSpan;

    public int ItemAddScore
    {
        get => _itemAddScore;
        set => _itemAddScore = value;
    }

    public int ItemPointLoss
    {
        get => _itemPointLoss;
        set => _itemPointLoss = value;
    }

    public int ItemLifeSpan
    {
        get => _itemLifeSpan;
        set => _itemLifeSpan = value;
    }

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
        yield return new WaitForSeconds(_itemLifeSpan);
        Debug.Log("Point loss: " + _itemPointLoss);
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Added Score: " + _itemAddScore);
    }
}