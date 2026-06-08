using System.Collections.Generic;
using System.Linq;
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
            go.SendMessage("Spawn", SendMessageOptions.DontRequireReceiver);

            return go;
        }

        public void Recycle(GameObject go)
        {
            foreach (var item in _objects.Where(item => item == go))
            {
                item.SendMessage("Recycle", SendMessageOptions.DontRequireReceiver);
                item.SetActive(false);
            }
        }

        public bool ContainObject(GameObject go)
        {
            return _objects.Contains(go);
        }
    }
}