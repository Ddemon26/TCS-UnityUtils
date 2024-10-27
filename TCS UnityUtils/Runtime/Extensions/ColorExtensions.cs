using System.Collections.Concurrent;
using System.Text;
using UnityEngine;

namespace TCS.UnityExtentions.Utils {
    public static class ColorExtensions {
        /// <summary>Colors a string using rich formatting and inserts the result into a string builder.</summary>
        /// <returns>The formatted text.</returns>
        /// <param name="stringBuilder">String builder to add the result into</param>
        /// <param name="text">The text to color.</param>
        /// <param name="color">The color to add to the text.</param>
        public static void AppendColoredText(this StringBuilder stringBuilder, string text, Color color) {
            if (string.IsNullOrWhiteSpace(text)) {
                stringBuilder.Append(text);
            }

            string hexColor = Color32ToStringNonAlloc(color);
            stringBuilder.Append("<#");
            stringBuilder.Append(hexColor);
            stringBuilder.Append('>');
            stringBuilder.Append(text);
            stringBuilder.Append("</color>");
        }

        static readonly ConcurrentDictionary<int, string> ColorLookupTable = new();
        public static unsafe string Color32ToStringNonAlloc(Color32 color) {
            int colorKey = color.r << 24 | color.g << 16 | color.b << 8 | color.a;
            if (ColorLookupTable.TryGetValue(colorKey, out string alloc)) {
                return alloc;
            }

            char* buffer = stackalloc char[8];
            Color32ToHexNonAlloc(color, buffer);

            int bufferLength = color.a < 0xFF ? 8 : 6;
            var colorText = new string(buffer, 0, bufferLength);

            ColorLookupTable[colorKey] = colorText;
            return colorText;
        }

        static unsafe void Color32ToHexNonAlloc(Color32 color, char* buffer) {
            ByteToHex(color.r, out buffer[0], out buffer[1]);
            ByteToHex(color.g, out buffer[2], out buffer[3]);
            ByteToHex(color.b, out buffer[4], out buffer[5]);
            ByteToHex(color.a, out buffer[6], out buffer[7]);
        }

        static void ByteToHex(byte value, out char dig1, out char dig2) {
            dig1 = NibbleToHex((byte)(value >> 4));
            dig2 = NibbleToHex((byte)(value & 0xF));
        }

        static char NibbleToHex(byte nibble) {
            if (nibble < 10) { return (char)('0' + nibble); }
            else { return (char)('A' + nibble - 10); }
        }
    }
}