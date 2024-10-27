using System.IO;

namespace TCS.UnityExtentions {
    public static class PathExtensions {
        public static string EnsureDirectory(this string path) {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public static string CombinePath(this string path, string fileName) {
            return Path.Combine(path, fileName);
        }
    }
}