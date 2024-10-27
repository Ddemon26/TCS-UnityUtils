using System;
namespace TCS.UnityExtentions {
    public static class StringExtensions {
        public static string OrDefault(this string value, string defaultValue) {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
        public static bool ContainsCaseInsensitive(this string source, string value) {
            return string.IsNullOrEmpty(source)
                ? string.IsNullOrEmpty(value)

#if UNITY_WEBGL && !UNITY_EDITOR
                : source.ToLower().Contains(value.ToLower());
#else
                : source.Contains(value, StringComparison.OrdinalIgnoreCase);
#endif
        }

        public static bool Contains(this string source, string value, StringComparison comp) {
            return source?.IndexOf(value, comp) >= 0;
        }

        public static int CountFromIndex(this string source, char target, int index) {
            var count = 0;
            for (int i = index; i < source.Length; i++) {
                if (source[i] == target) {
                    count++;
                }
            }

            return count;
        }
    }
}