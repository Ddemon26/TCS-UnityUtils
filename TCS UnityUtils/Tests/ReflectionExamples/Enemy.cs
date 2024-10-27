using UnityEngine;
namespace TCS.UnityUtils.Tests {
    public class Enemy : MonoBehaviour {
        void Start() => Invoke(nameof(Spawn), 2f);

        void Spawn() {
            Debug.Log("Enemy has spawned.");
            EventManager.TriggerEvent("EnemySpawned", "Enemy1");
        }
    }
}