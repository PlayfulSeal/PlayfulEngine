using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class Debug {

        public static bool DebugMode { get; set; }

        public static void Log(object message) {
            Console.WriteLine($"[INFO] {message}");
        }

        public static void LogWarning(object message) {
            Console.WriteLine($"[WARN] {message}");
        }

        public static void LogError(object message, bool shouldCrash = true) {
            Console.WriteLine($"[ERROR] {message}");

            if(shouldCrash) {
                throw new Exception("Exception: " + message);
            }
        }

    }
}
