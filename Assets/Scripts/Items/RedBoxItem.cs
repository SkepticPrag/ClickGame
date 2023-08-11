using Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class RedBoxItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.ChangeScore(ItemAddScore);
            Debug.Log("Red Box Item Clicked.");
            gameObject.SetActive(false);
        }
    }
}
