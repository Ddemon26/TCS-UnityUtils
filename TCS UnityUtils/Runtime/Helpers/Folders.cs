using System.IO;
using UnityEditor;
using UnityEngine;
namespace TCS.Infrastructure {
    public static class Folders {   
#if UNITY_EDITOR
        public static void Create(string root, params string[] folders) {
            string fullpath = Path.Combine(Application.dataPath, root);
            if (!Directory.Exists(fullpath)) {
                Directory.CreateDirectory(fullpath);
            }

            foreach (string folder in folders) {
                CreateSubFolders(fullpath, folder);
            }
        }

        static void CreateSubFolders(string rootPath, string folderHierarchy) {
            string[] folders = folderHierarchy.Split('/');
            string currentPath = rootPath;

            foreach (string folder in folders) {
                currentPath = Path.Combine(currentPath, folder);
                if (!Directory.Exists(currentPath)) {
                    Directory.CreateDirectory(currentPath);
                }
            }
        }

        public static void Move(string newParent, string folderName) {
            var sourcePath = $"Assets/{folderName}";
            if (!AssetDatabase.IsValidFolder(sourcePath)) return;
            var destinationPath = $"Assets/{newParent}/{folderName}";
            string error = AssetDatabase.MoveAsset(sourcePath, destinationPath);

            if (!string.IsNullOrEmpty(error)) {
                Debug.LogError($"Failed to move {folderName}: {error}");
            }
        }

        public static void Delete(string folderName) {
            var pathToDelete = $"Assets/{folderName}";

            if (AssetDatabase.IsValidFolder(pathToDelete)) {
                AssetDatabase.DeleteAsset(pathToDelete);
            }
        }
#endif
    }
}