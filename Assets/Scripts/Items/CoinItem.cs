using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class CoinItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Coin Item Clicked.");
        }
    }
}
