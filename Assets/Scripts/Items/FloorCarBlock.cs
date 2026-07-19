using UnityEngine;

namespace Items
{
    public class FloorCarBlock : Obstacle
    {
        public override void Spawn()
        {
            throw new System.NotImplementedException();
        }

        public override void Recycle()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnHitPlayer()
        {
            Destroy(gameObject);
        }
    }
}