using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class RedBoxItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Red Box Item Clicked.");
        }
    }
}
