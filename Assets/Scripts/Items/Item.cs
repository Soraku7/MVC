using Global;
using UnityEngine;

namespace Items
{
    public abstract class Item : ReusableItem
    {
        protected virtual void LateUpdate()
        {
            transform.Rotate(Vector3.up * (angular * Time.deltaTime));
        }
    }
}