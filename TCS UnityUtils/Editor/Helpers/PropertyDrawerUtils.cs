using UnityEditor;
using UnityEngine;
namespace TCS.UnityUtils.Editor.Extensions {
    public static class PropertyDrawerUtils {
        /// <summary>
        /// Removes an element at the specified index from a SerializedProperty array.
        /// </summary>
        /// <param name="drawer">The PropertyDrawer instance.</param>
        /// <param name="arrayProperty">The SerializedProperty array.</param>
        /// <param name="index">The index of the element to remove.</param>
        public static void RemoveElementAtIndex(PropertyDrawer drawer, SerializedProperty arrayProperty, int index) {
            if (arrayProperty == null || index < 0 || index >= arrayProperty.arraySize) return;
            var element = arrayProperty.GetArrayElementAtIndex(index);

            if (element.propertyType == SerializedPropertyType.ManagedReference) {
                element.managedReferenceValue = null;
            }

            arrayProperty.DeleteArrayElementAtIndex(index);
        }

        /// <summary>
        /// Moves an element within a SerializedProperty array from one index to another.
        /// </summary>
        /// <param name="drawer">The PropertyDrawer instance.</param>
        /// <param name="arrayProperty">The SerializedProperty array.</param>
        /// <param name="fromIndex">The index of the element to move.</param>
        /// <param name="toIndex">The index to move the element to.</param>
        public static void MoveElement(PropertyDrawer drawer, SerializedProperty arrayProperty, int fromIndex, int toIndex) {
            if (arrayProperty != null &&
                fromIndex >= 0 && fromIndex < arrayProperty.arraySize &&
                toIndex >= 0 && toIndex < arrayProperty.arraySize) {
                arrayProperty.MoveArrayElement(fromIndex, toIndex);
            }
        }

        /// <summary>
        /// Creates a Texture2D with the specified width, height, and color.
        /// </summary>
        /// <param name="drawer">The PropertyDrawer instance.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="col">The color to fill the texture with.</param>
        /// <returns>A new Texture2D filled with the specified color.</returns>
        public static Texture2D MakeTex(PropertyDrawer drawer, int width, int height, Color col) {
            Color[] pix = new Color[width * height];

            for (var i = 0; i < pix.Length; i++)
                pix[i] = col;

            var result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }
    }
}