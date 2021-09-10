using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    /// <summary>
    /// A script to attach to a <see cref="GameObject"/>
    /// </summary>
    public class GOScript {

        /// <summary>
        /// The <see cref="GameObject"/> the <see cref="GOScript"/> is attached to
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// Runs when the <see cref="GOScript"/> is attached to the <see cref="GameObject"/>
        /// </summary>
        public virtual void OnStart() { }

        /// <summary>
        /// Runs with <see cref="GameObject.Tick"/>
        /// </summary>
        public virtual void Tick() { }

        /// <summary>
        /// Runs with <see cref="GameObject.Render"/>
        /// </summary>
        public virtual void Render() { }

    }
}
