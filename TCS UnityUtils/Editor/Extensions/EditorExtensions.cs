using System.IO;
using UnityEditor;
using UnityEngine;

namespace TCS.UnityExtentions {
    public static class EditorExtensions {
        public static bool ConfirmOverwrite(this string path) {
#if UNITY_EDITOR
            if (File.Exists(path)) {
                return EditorUtility.DisplayDialog
                (
                    "File Exists",
                    "The file already exists at the specified path. Do you want to overwrite it?",
                    "Yes",
                    "No"
                );
            }

            return true;
#endif
        }

        public static string BrowseForFolder(this string defaultPath) {
#if UNITY_EDITOR
            return EditorUtility
                .SaveFolderPanel
                (
                    "Choose Save Path",
                    defaultPath,
                    ""
                );
#endif
        }

        public static void PingAndSelect(this Object asset) {
#if UNITY_EDITOR
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
#endif
        }
    }
}