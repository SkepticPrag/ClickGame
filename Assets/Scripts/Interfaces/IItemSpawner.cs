using UnityEngine;

namespace Interfaces
{
    public interface IItemSpawner
    {
        public void OnItemSpawn(bool isActive, Vector3 position, Quaternion rotation);
    }
}
