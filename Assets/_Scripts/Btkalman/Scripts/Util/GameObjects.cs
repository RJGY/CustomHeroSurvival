using System.Collections.Generic;
using UnityEngine;

namespace Btkalman.Util {
    public class GameObjects {
        public static float Distance(GameObject a, GameObject b) {
            return (a.transform.position - b.transform.position).magnitude;
        }

        public static float Distance(Component a, Component b) {
            return (a.transform.position - b.transform.position).magnitude;
        }

        public static T GetComponentWithTagInChildren<T>(GameObject obj, string tag) {
            foreach (var t in obj.GetComponentsInChildren<T>()) {
                if ((t as Component).tag == tag) {
                    return t;
                }
            }
            return default(T);
        }

        public static T GetComponentWithTagInChildren<T>(Component c, string tag) {
            return GetComponentWithTagInChildren<T>(c.gameObject, tag);
        }

        public static List<GameObject> GetObjectsWithTagInDescendents(
                GameObject obj, string tag, List<GameObject> list = null) {
            if (list == null) {
                list = new List<GameObject>();
            }
            foreach (Transform child in obj.transform) {
                if (child.tag == tag) {
                    list.Add(child.gameObject);
                }
                GetObjectsWithTagInDescendents(child.gameObject, tag, list);
            }
            return list;
        }
    }
}