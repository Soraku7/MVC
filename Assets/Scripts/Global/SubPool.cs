using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class SubPool : MonoBehaviour
    {
        public string subName;
        public GameObject prefab;
        private List<GameObject> _objects;

        public SubPool(GameObject prefab, string name)
        {
            this.prefab = prefab;
            this.subName = name;
        }

        public GameObject Spawn()
        {
            _objects ??= new List<GameObject>();

            GameObject go = null;
            foreach (GameObject obj in _objects)
            {
                if (obj.activeInHierarchy == false)
                {
                    go = obj;
                    break;
                }
            }

            if (go == null)
            {
                go = Instantiate(prefab);
                _objects.Add(go);
            }

            go.SetActive(true);

            return go;
        }

        public void Recycle(GameObject go)
        {
            _objects.Find(x => x.GetHashCode() == go.GetHashCode()).gameObject.SetActive(false);
        }

        public bool ContainObject(GameObject go)
        {
            return _objects.Contains(go);
        }
    }
}