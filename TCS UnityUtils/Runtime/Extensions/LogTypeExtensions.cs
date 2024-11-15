using UnityEngine;

namespace TCS.UnityExtentions.Utils {
    public enum LoggingType {
        Never = 0,
        Always = 1,
        Warning = 2,
        Error = 3,
        Exception = 4,
    }
    public static class LogTypeExtensions {
        public static LoggingType ToLoggingThreshold(this LogType logType) {
            var severity = logType switch {
                LogType.Exception => LoggingType.Exception,
                LogType.Error => LoggingType.Error,
                LogType.Assert => LoggingType.Error,
                LogType.Warning => LoggingType.Warning,
                LogType.Log => LoggingType.Always,
                _ => LoggingType.Always,
            };

            return severity;
        }
    }
}