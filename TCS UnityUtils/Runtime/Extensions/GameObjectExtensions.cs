using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TCS.UnityExtentions.Utils {
    public static class GameObjectExtensions {
        static readonly Dictionary<string, GameObject> GameObjectCache = new();
        static readonly List<GameObject> RootGameObjectBuffer = new();

        public static GameObject Find(string name, bool includeInactive = false) {
            if (GameObjectCache.TryGetValue(name, out var obj)
                && obj
                && obj.activeInHierarchy | includeInactive
                && obj.name == name) {
                return obj;
            }

            obj = GameObject.Find(name);
            if (obj) {
                return GameObjectCache[name] = obj;
            }

            if (includeInactive) {
                int sceneCount = SceneManager.sceneCountInBuildSettings;
                for (var i = 0; i < sceneCount; i++) {
                    var scene = SceneManager.GetSceneByBuildIndex(i);
                    if (scene.isLoaded) {
                        RootGameObjectBuffer.Clear();
                        scene.GetRootGameObjects(RootGameObjectBuffer);

                        foreach (var root in RootGameObjectBuffer) {
                            obj = Find(name, root);
                            if (obj) {
                                return GameObjectCache[name] = obj;
                            }
                        }
                    }
                }

                obj = Resources
                    .FindObjectsOfTypeAll<GameObject>()
                    .Where(x => !x.hideFlags.HasFlag(HideFlags.HideInHierarchy))
                    .FirstOrDefault(x => x.name == name);

                if (obj) {
                    return GameObjectCache[name] = obj;
                }
            }

            return null;
        }

        public static GameObject Find(string name, GameObject root) {
            if (root.name == name) {
                return root;
            }

            for (var i = 0; i < root.transform.childCount; i++) {
                var obj = Find(name, root.transform.GetChild(i).gameObject);
                if (obj) {
                    return obj;
                }
            }

            return null;
        }
    }
}