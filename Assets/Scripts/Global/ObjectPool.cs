using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class ObjectPool : MonoBehaviour
    {
        private Dictionary<string, SubPool> _subPools = new Dictionary<string, SubPool>();
        private string resourcesPath = "Objects";

        public GameObject Spawn(string name)
        {
            _subPools ??= new Dictionary<string, SubPool>();

            return _subPools.TryGetValue(name, out SubPool pool) ? pool.Spawn() : ConstractNewSub(name);
        }

        public void Recycle(GameObject go)
        {
            foreach (SubPool subPool in _subPools.Values)
            {
                if (subPool.ContainObject(go))
                {
                    subPool.Recycle(go);
                }
            }
        }

        private GameObject ConstractNewSub(string name)
        {
            string path = resourcesPath + "/" + name;
            GameObject go = Resources.Load<GameObject>(path);
            SubPool subPool = new SubPool(go, name);
            _subPools[subPool.subName] = subPool;

            return subPool.Spawn();
        }
    }
}