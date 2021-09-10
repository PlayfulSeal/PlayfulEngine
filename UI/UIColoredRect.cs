using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine.UI {
    /// <summary>
    /// A colored rectangle that is draw as UI
    /// </summary>
    public class UIColoredRect : UIBase {

        /// <summary>
        /// The rectangle to be drawn
        /// </summary>
        public Rectangle rect { get; private set; }

        /// <summary>
        /// The color of the rectangle
        /// </summary>
        public Color color { get; private set; }

        /// <summary>
        /// The texture of the rectangle
        /// </summary>
        private Texture2D _texture;

        /// <summary>
        /// Creates a colored rectangle that is draw as UI
        /// </summary>
        /// <param name="rect">The rectangle to be drawn</param>
        /// <param name="color">The color of the rectangle</param>
        public UIColoredRect(Rectangle rect, Color color) : base(new Vector2(rect.X, rect.Y)) {
            SetRectangle(rect); // Sets the rectangle, color and texture
        }

        /// <summary>
        /// Sets the color of the rectangle
        /// </summary>
        /// <param name="newColor">The new color</param>
        public void SetColor(Color newColor) {
            color = newColor; // Set the color

            _texture = new Texture2D(EngineGlobals.GRAPHICS_DEVICE_MANAGER.GraphicsDevice, rect.Width, rect.Height); // Create the texture

            Color[] _color = new Color[rect.Width * rect.Height]; // Create the color data

            for (int i = 0; i < _color.Length; i++) {
                _color[i] = color;
            }

            _texture.SetData(_color); // Sets the color data
        }

        /// <summary>
        /// Sets the rectangle
        /// </summary>
        /// <param name="rect"></param>
        public void SetRectangle(Rectangle rect) {
            this.rect = rect; // Set the rectangle
            SetColor(color); // Set the color
        }

        public override void Render() {
            EngineGlobals.SPRITE_BATCH.Draw(_texture, rect, Color.White); // Render the rect
        }
    }
}
