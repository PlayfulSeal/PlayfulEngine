using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine.Exceptions {
    public class MissingScriptException : Exception {

        public MissingScriptException(GOScript script) : base("Missing script: " + script.ToString()) {

        }

        public MissingScriptException(string info) : base("Missing script: " + info) {
            Debug.LogError("Missing script: " + info, false);
        }
    }
}
