using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TCS.UnityUtils.Tests {
    internal static class EventManager {
        static readonly Dictionary<string, Action<object>> Events = new();

        public static void Init() => BindEventListeners();

        static void BindEventListeners() {
            MonoBehaviour[] monoBehaviours = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

            foreach (var mb in monoBehaviours) {
                var type = mb.GetType();
                MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                foreach (var method in methods) {
                    IEnumerable<EventListenerAttribute> attributes = method.GetCustomAttributes<EventListenerAttribute>();
                    foreach (var attr in attributes) {
                        if (!ValidateMethod(method, type)) continue;

                        string eventName = attr.EventName;
                        if (!Events.TryGetValue(eventName, out Action<object> _)) {
                            Events[eventName] = null; // Initialize event with null handler list
                        }

                        Action<object> action = (Action<object>)Delegate.CreateDelegate(typeof(Action<object>), mb, method);
                        Events[eventName] += action;
                        Debug.Log($"Bound method {method.Name} from {type.Name} to event '{eventName}'.");
                    }
                }
            }
        }

        static bool ValidateMethod(MethodInfo method, Type type) {
            if (method.ReturnType != typeof(void)) {
                Debug.LogError($"Method {method.Name} in {type.Name} must return void to be an event listener.");
                return false;
            }

            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length == 1 && typeof(object).IsAssignableFrom(parameters[0].ParameterType)) return true;
            Debug.LogError($"Method {method.Name} in {type.Name} must have exactly one parameter of type object.");
            return false;

        }

        public static void TriggerEvent(string eventName, object data = null) {
            if (!Events.TryGetValue(eventName, out Action<object> handlers) || handlers == null) {
                Debug.LogWarning($"Event '{eventName}' has no handlers bound or does not exist.");
                return;
            }

            foreach (var @delegate in handlers.GetInvocationList()) {
                Action<object> handler = (Action<object>)@delegate;
                try {
                    handler(data);
                }
                catch (Exception ex) {
                    Debug.LogError($"Error invoking handler for event '{eventName}': {ex.Message}");
                }
            }
        }

        public static void AddEvent(string eventName) {
            if (Events.TryAdd(eventName, null)) {
                Debug.Log($"Added new event '{eventName}'.");
            }
            else {
                Debug.LogWarning($"Event '{eventName}' already exists.");
            }
        }

        public static void RemoveEvent(string eventName) {
            if (Events.Remove(eventName)) {
                Debug.Log($"Removed event '{eventName}' and all its handlers.");
            }
            else {
                Debug.LogWarning($"Event '{eventName}' does not exist.");
            }
        }
    }
}
