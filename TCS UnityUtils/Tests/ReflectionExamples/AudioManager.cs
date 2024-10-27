using UnityEngine;
namespace TCS.UnityUtils.Tests {
    public class AudioManager : MonoBehaviour {
        [EventListener("PlayerDied")]
        void PlayDeathSound(object data) {
            Debug.Log("AudioManager received PlayerDied event. Playing death sound.");
        }

        [EventListener("EnemySpawned")]
        void PlaySpawnSound(object data) {
            Debug.Log($"AudioManager received EnemySpawned event with data: {data}");
        }
    }
}