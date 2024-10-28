using UnityEditor;
using UnityEngine;
namespace TCS.UnityUtils.Editor.Extensions {
    public static class PropertyDrawerUtils {
        public static void RemoveElementAtIndex(this PropertyDrawer drawer, SerializedProperty arrayProperty, int index) {
            if (arrayProperty == null || index < 0 || index >= arrayProperty.arraySize) return;
            var element = arrayProperty.GetArrayElementAtIndex(index);

            if (element.propertyType == SerializedPropertyType.ManagedReference) {
                element.managedReferenceValue = null;
            }

            arrayProperty.DeleteArrayElementAtIndex(index);
        }

        public static void MoveElement(this PropertyDrawer drawer, SerializedProperty arrayProperty, int fromIndex, int toIndex) {
            if (arrayProperty != null &&
                fromIndex >= 0 && fromIndex < arrayProperty.arraySize &&
                toIndex >= 0 && toIndex < arrayProperty.arraySize) {
                arrayProperty.MoveArrayElement(fromIndex, toIndex);
            }
        }

        public static Texture2D MakeTex(this PropertyDrawer drawer, int width, int height, Color col) {
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