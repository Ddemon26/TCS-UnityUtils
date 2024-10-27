using UnityEngine;
namespace TCS.Infrastructure {
    public static class JsonSerializer {
        /// <summary>
        /// Deserializes a JSON string from a TextAsset into an object of type T.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="json">The TextAsset containing the JSON string.</param>
        /// <returns>An object of type T deserialized from the JSON string.</returns>
        public static T FromTextAsset<T>(TextAsset json) => JsonUtility.FromJson<T>(json.text);
    }
}