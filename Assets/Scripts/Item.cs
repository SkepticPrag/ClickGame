using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IItem
{
    [SerializeField] ScriptableItem scriptableItemInstance;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DespawnItem());
    }
    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public IEnumerator DespawnItem()
    {
        yield return new WaitForSeconds(scriptableItemInstance.lifeSpan);
        gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Hello World");
    }
}