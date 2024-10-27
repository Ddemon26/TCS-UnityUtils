using System;
namespace TCS.UnityUtils.Tests {
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    internal class EventListenerAttribute : Attribute {
        public string EventName { get; }

        public EventListenerAttribute(string eventName) {
            EventName = eventName;
        }
    }
}