using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class YellowBlockItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.ChangeScore(ItemAddScore);
            Debug.Log("Yellow Block Item Clicked.");
            gameObject.SetActive(false);
        }
    }
}
