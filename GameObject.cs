using Microsoft.Xna.Framework;
using PlayfulEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class GameObject {

        /// <summary>
        /// The <see cref="GOScript"/> list
        /// </summary>
        private Dictionary<string, GOScript> _scripts = new Dictionary<string, GOScript>();

        /// <summary>
        /// The <see cref="Transform"/> of the <see cref="GameObject"/>
        /// </summary>
        public Transform transform;

        /// <summary>
        /// Adds a <see cref="GOScript"/> to the <see cref="GameObject"/> [WARNING: ONLY ONE OF EACH TYPE OF SCRIPT]
        /// </summary>
        /// <param name="script">The <see cref="GOScript"/> to add</param>
        public void AddScript(string label, GOScript script) {
            if(!_scripts.ContainsKey(label)) { // If it isn't added to the GO
                Debug.Log("Adding script: " + label);
                script.gameObject = this;
                _scripts.Add(label, script); // Add it

                script.OnStart(); // Run it's start method
            }
        }

        /// <summary>
        /// Gets a <see cref="GOScript"/> attached to the <see cref="GameObject"/>
        /// </summary>
        /// <typeparam name="T">Type of <see cref="GOScript"/></typeparam>
        /// <returns>Either the <see cref="GOScript"/> or null</returns>
        public GOScript GetScript(string label) {
            if (_scripts.ContainsKey(label)) {
                return _scripts[label];
            }

            throw new MissingScriptException($"{this.ToString()}:{label}");
        }

        /// <summary>
        /// Removes a <see cref="GOScript"/> from the <see cref="GameObject"/>
        /// </summary>
        /// <typeparam name="T">Type of <see cref="GOScript"/></typeparam>
        public void RemoveScript(string label) {
            if (_scripts.ContainsKey(label)) {
                _scripts.Remove(label);
            }

            return;
        }

        /// <summary>
        /// Creates a new <see cref="GameObject"/>
        /// </summary>
        public GameObject() {
            transform = new Transform();
            Init();
        }

        /// <summary>
        /// Creates a new <see cref="GameObject"/>
        /// </summary>
        /// <param name="position">The position of the <see cref="GameObject"/></param>
        public GameObject(Vector2 position) {
            transform = new Transform(position);
            Init();
        }

        /// <summary>
        /// Creates a new <see cref="GameObject"/>
        /// </summary>
        /// <param name="transform">The <see cref="Transform"/> of the <see cref="GameObject"/></param>
        public GameObject(Transform transform) {
            this.transform = transform;
            Init();
        }

        /// <summary>
        /// Initalizes the <see cref="GameObject"/>
        /// </summary>
        public virtual void Init() {
            return;
        }

        /// <summary>
        /// Renders the <see cref="GameObject"/>
        /// </summary>
        public void Render() {
            foreach(GOScript script in _scripts.Values) {
                script.Render();
            }
        }


        /// <summary>
        /// Updates the <see cref="GameObject"/>
        /// </summary>
        public void Tick() {
            foreach (GOScript script in _scripts.Values) {
                script.Tick();
            }
        }
    }
}
