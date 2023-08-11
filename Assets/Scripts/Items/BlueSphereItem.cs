using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class BlueSphereItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.ChangeScore(ItemAddScore);
            Debug.Log("Blue Sphere Item Clicked.");
            gameObject.SetActive(false);
        }
    }
}
