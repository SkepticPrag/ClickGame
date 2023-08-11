using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class YellowBlockItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Yellow Block Item Clicked.");
        }
    }
}
