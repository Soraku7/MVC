using Global;
using UnityEngine;

namespace Items
{
    public abstract class Item : ReusableItem
    {
        public int angular = 180;
        protected virtual void LateUpdate()
        {
            transform.Rotate(Vector3.up * (angular * Time.deltaTime));
        }
    }
}