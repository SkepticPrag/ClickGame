using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class TargetItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Target Item Clicked. Spawning 5 Coins...");
        }
    }
}