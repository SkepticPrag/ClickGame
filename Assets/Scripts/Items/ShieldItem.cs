using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class ShieldItem : Item
    {
        private int _clicksPerformed;

        public ShieldItem()
        {
            _clicksPerformed = 0;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            _clicksPerformed++;
            if (_clicksPerformed >= ClicksNeeded)
                Debug.Log("Shield Item Clicked.");
        }
    }
}