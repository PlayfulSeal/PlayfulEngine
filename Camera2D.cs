using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    /// <summary>
    /// Do not create a camera!
    /// </summary>
    public class Camera2D {

        private float _zoom; // Camera Zoom
        private Matrix _transform; // Matrix Transform
        private Vector2 _pos; // Camera Position
        private float _rotation; // Camera Rotation

        /// <summary>
        /// DO NOT USE!
        /// </summary>
        public Camera2D() {
            _zoom = 1.0f;
            _rotation = 0.0f;
            _pos = Vector2.Zero;
        }

        /// <summary>
        /// Sets the zoom of the <see cref="Camera2D"/>
        /// </summary>
        public float Zoom {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        /// <summary>
        /// Sets the rotation of the <see cref="Camera2D"/>
        /// </summary>
        public float Rotation {
            get { return _rotation; }
            set { _rotation = value; }
        }

        /// <summary>
        ///  Auxiliary function to move the <see cref="Camera2D"/>
        /// </summary>
        /// <param name="amount"></param>
        public void Move(Vector2 amount) {
            _pos += amount;
        }

        /// <summary>
        /// The position of the <see cref="Camera2D"/>
        /// </summary>
        public Vector2 Pos {
            get { return _pos; }
            set { _pos = value; }
        }

        /// <summary>
        /// Gets the transformation matrix of the <see cref="Camera2D"/>
        /// </summary>
        /// <returns>Transformation matrix</returns>
        public Matrix GetTransformation() {
            _transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(EngineGlobals.GRAPHICS_DEVICE_MANAGER.GraphicsDevice.Viewport.Width * 0.5f, EngineGlobals.GRAPHICS_DEVICE_MANAGER.GraphicsDevice.Viewport.Height * 0.5f, 0));
            return _transform;
        }

    }
}
