using UnityEngine;

namespace TCS.UnityUtils.Examples {
    public class FastRandomExample : MonoBehaviour {
        FastRandom m_random;

        void Start() {
            // Create an instance of FastRandom
            m_random = new FastRandom();

            // Generate a random integer
            int randomInt = m_random.Next();
            Debug.Log($"Random Int: {randomInt}");

            // Generate a random integer within a range
            int randomIntInRange = m_random.Next(1, 100);
            Debug.Log($"Random Int in Range [1, 100): {randomIntInRange}");

            // Generate a random double
            double randomDouble = m_random.NextDouble();
            Debug.Log($"Random Double: {randomDouble}");

            // Generate a random float
            float randomFloat = m_random.NextFloat();
            Debug.Log($"Random Float: {randomFloat}");

            // Generate a random boolean
            bool randomBool = m_random.NextBool();
            Debug.Log($"Random Bool: {randomBool}");

            // Generate a random byte array
            var byteArray = new byte[10];
            m_random.NextBytes(byteArray);
            Debug.Log("Random Byte Array: " + System.BitConverter.ToString(byteArray));

            // Generate a random float array
            var floatArray = new float[5];
            m_random.NextFloats(floatArray);
            Debug.Log("Random Float Array: " + string.Join(", ", floatArray));
        }
    }
}