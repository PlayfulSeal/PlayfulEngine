using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class Transform {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;

        public Transform() {
            position = Vector2.Zero;
            rotation = 0;
            scale = Vector2.One;
        }

        public Transform(Vector2 position) {
            this.position = position;
            rotation = 0;
            scale = Vector2.One;
        }

        public Transform(Vector2 position, float rotation) {
            this.position = position;
            this.rotation = rotation;
            scale = Vector2.One;
        }

        public Transform(Vector2 position, float rotation, Vector2 scale) {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}
