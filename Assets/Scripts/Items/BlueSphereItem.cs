using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class BlueSphereItem : Item
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Blue Sphere Item Clicked.");
        }
    }
}
