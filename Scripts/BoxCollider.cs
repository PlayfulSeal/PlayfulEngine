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

        private int xOffset, yOffset;

        /// <summary>
        /// Creates a <see cref="BoxCollider"/> with the widht and height
        /// </summary>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        public BoxCollider(int width, int height) {
            _colliderRect = new Rectangle(0, 0, width, height); // Create the new rectangle
            xOffset = 0;
            yOffset = 0;
            _colliders.Add(this); // Add this collider to the list
        }

        /// <summary>
        /// Creates a <see cref="BoxCollider"/> with the widht and height
        /// </summary>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        public BoxCollider(int xOffset, int yOffset, int width, int height) {
            _colliderRect = new Rectangle(xOffset, yOffset, width, height); // Create the new rectangle
            this.xOffset = xOffset;
            this.yOffset = yOffset;
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

                    Rectangle _tempColliderHorizontal, _tempColliderVertical;

                    if (velocity.X > 0) {
                        _tempColliderHorizontal = new Rectangle(_colliderRect.X + (int)velocity.X + 1, _colliderRect.Y, _colliderRect.Width, _colliderRect.Height);
                    } else if (velocity.X < 0) {
                        _tempColliderHorizontal = new Rectangle(_colliderRect.X + (int)velocity.X - 1, _colliderRect.Y, _colliderRect.Width, _colliderRect.Height);
                    } else {
                        _tempColliderHorizontal = new Rectangle(_colliderRect.X + (int)velocity.X, _colliderRect.Y, _colliderRect.Width, _colliderRect.Height);
                    }

                    if (velocity.Y > 0) {
                        _tempColliderVertical = new Rectangle(_colliderRect.X, _colliderRect.Y + (int)velocity.Y + 1, _colliderRect.Width, _colliderRect.Height);
                    }
                    else if (velocity.Y < 0) {
                        _tempColliderVertical = new Rectangle(_colliderRect.X, _colliderRect.Y + (int)velocity.Y - 1, _colliderRect.Width, _colliderRect.Height);
                    }
                    else {
                        _tempColliderVertical = new Rectangle(_colliderRect.X, _colliderRect.Y + (int)velocity.Y, _colliderRect.Width, _colliderRect.Height);
                    }

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
            _colliderRect.X = (int) gameObject.transform.position.X + xOffset; // Updates the rect's X
            _colliderRect.Y = (int)gameObject.transform.position.Y + yOffset; // Updates the rect's Y
        }

        public override void Render() {
            if (Debug.DebugMode) {
                EngineGlobals.SPRITE_BATCH.Draw(GameManager.ENGINE_SPRITES.rawTexture, _colliderRect, new Rectangle(0, 0, 16, 16), Color.White);
            }
        }
    }
}
