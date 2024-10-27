using System;
using System.IO;
using UnityEditor;
namespace TCS.Infrastructure {
    public static class Assets {    
        public static void ImportAsset(string asset, string folder) {
#if UNITY_EDITOR
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string assetsFolder = Path.Combine(basePath, "Unity/Asset Store-5.x");
            AssetDatabase.ImportPackage(Path.Combine(assetsFolder, folder, asset), false);
#endif
        }
    }
}