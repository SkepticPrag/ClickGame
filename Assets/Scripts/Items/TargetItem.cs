using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class TargetItem : Item
    {
        private float _distFromCamera = 10.0f;

        public override void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.ChangeScore(ItemAddScore);
            Debug.Log("Target Item Clicked. Spawning 5 Coins...");

            for (int i = 0; i < 5; i++)
            {
                Vector3 _pos = new Vector3(Random.value, Random.value, _distFromCamera);
                _pos = Camera.main.ViewportToWorldPoint(_pos);
                ObjectPooler.Instance.SpawnFromPool("Coin", _pos, Quaternion.identity);
            }

            gameObject.SetActive(false);
        }
    }
}