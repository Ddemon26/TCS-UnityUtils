using UnityEngine;
namespace TCS.UnityUtils.Tests {
    public class Player : MonoBehaviour {
        void Start() => Invoke(nameof(Die), 5f);

        void Die() {
            Debug.Log("Player has died.");
            EventManager.TriggerEvent("PlayerDied", null);
        }
    }
}