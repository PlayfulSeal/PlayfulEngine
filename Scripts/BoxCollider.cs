using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine.Scripts {

    /// <summary>
    /// Script used to detect collisions between one <see cref="GameObject"/> and another
    /// </summary>
    public class BoxCollider : GOScript {

        /// <summary>
        /// List of every <see cref="BoxCollider"/>
        /// </summary>
        private static List<BoxCollider> _colliders = new List<BoxCollider>();

        /// <summary>
        /// The rectangle used to detect collisions
        /// </summary>
        private Rectangle _colliderRect;

        /// <summary>
        /// Creates a <see cref="BoxCollider"/> with the widht and height
        /// </summary>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        public BoxCollider(int width, int height) {
            _colliderRect = new Rectangle(0, 0, width, height); // Create the new rectangle
            _colliders.Add(this); // Add this collider to the list
        }

        /// <summary>
        /// Checks for collisions based on the velocity of the <see cref="GameObject"/>
        /// </summary>
        /// <param name="velocity">The velocity of the <see cref="GameObject"/></param>
        /// <returns>A modified version of the velocity that won't collide</returns>
        public Vector2 CheckFutureCollisions(Vector2 velocity) {
            foreach(BoxCollider _collider in _colliders) { // For every box collider
                if(_collider != this) { // That isn't this
                    Rectangle _tempColliderHorizontal = new Rectangle(_colliderRect.X + (int)velocity.X, _colliderRect.Y, _colliderRect.Width, _colliderRect.Height);
                    Rectangle _tempColliderVertical = new Rectangle(_colliderRect.X, _colliderRect.Y + (int)velocity.Y, _colliderRect.Width, _colliderRect.Height);

                    if (_tempColliderHorizontal.Intersects(_collider._colliderRect)) { // Check if it will intersect on the X axis
                        velocity.X = 0f;
                    }

                    if (_tempColliderVertical.Intersects(_collider._colliderRect)) { // Check if it will intersect on the Y axis
                        velocity.Y = 0f;
                    }
                }
            }

            return velocity; // Return the modified velocity
        }

        public override void Tick() {
            _colliderRect.X = (int) gameObject.transform.position.X; // Updates the rect's X
            _colliderRect.Y = (int)gameObject.transform.position.Y; // Updates the rect's Y
        }
    }
}
