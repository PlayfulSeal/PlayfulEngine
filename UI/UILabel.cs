using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine.UI {
    /// <summary>
    /// Draws text to the screen
    /// </summary>
    public class UILabel : UIBase {

        /// <summary>
        /// The text to be drawn
        /// </summary>
        public string text;

        /// <summary>
        /// The color of the text
        /// </summary>
        public Color color;

        /// <summary>
        /// The font of the text
        /// </summary>
        public SpriteFontBase font;

        /// <summary>
        /// Creates a new <see cref="UILabel"/>
        /// </summary>
        /// <param name="position">Where the text show render</param>
        /// <param name="text">The text to render</param>
        /// <param name="font">The font to render with</param>
        public UILabel(Vector2 position, string text, SpriteFontBase font) : base(position){
            this.text = text;
            color = Color.White;
            this.font = font;
        }

        /// <summary>
        /// Creates a new <see cref="UILabel"/>
        /// </summary>
        /// <param name="position">Where the text show render</param>
        /// <param name="text">The text to render</param>
        /// <param name="font">The font to render with</param>
        /// <param name="color">The color of the text</param>
        public UILabel(Vector2 position, string text, Color color, SpriteFontBase font) : base(position) {
            this.text = text;
            this.color = color;
            this.font = font;
        }

        public override void Render() {
            EngineGlobals.SPRITE_BATCH.DrawString(font, text, position, color); // Render the text
        }
    }
}
