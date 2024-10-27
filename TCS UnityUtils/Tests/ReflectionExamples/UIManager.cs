using UnityEngine;
namespace TCS.UnityUtils.Tests {
    public class UIManager : MonoBehaviour {
        [EventListener("PlayerDied")]
        void OnPlayerDied(object data) {
            Debug.Log("UIManager received PlayerDied event. Displaying game over screen.");
        }

        [EventListener("EnemySpawned")]
        void OnEnemySpawned(object data) {
            Debug.Log($"UIManager received EnemySpawned event with data: {data}");
        }
    }
}