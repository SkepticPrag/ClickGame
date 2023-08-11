using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class CoinItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.ChangeScore(ItemAddScore);
            Debug.Log("Coin Item Clicked.");
            gameObject.SetActive(false);
        }
    }
}
