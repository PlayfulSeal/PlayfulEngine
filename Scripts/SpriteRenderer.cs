using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine.Scripts {
    /// <summary>
    /// Renders a <see cref="Sprite"/> at the position of the <see cref="GameObject"/>
    /// </summary>
    public class SpriteRenderer : GOScript {

        /// <summary>
        /// <see cref="Sprite"/> to render
        /// </summary>
        public Sprite sprite;

        /// <summary>
        /// What color the <see cref="Sprite"/> will be
        /// </summary>
        public Color spriteColor;

        /// <summary>
        /// Creates a <see cref="SpriteRenderer"/>
        /// </summary>
        /// <param name="sprite">The <see cref="Sprite"/> to render</param>
        public SpriteRenderer(Sprite sprite) {
            this.sprite = sprite;
            spriteColor = Color.White;
        }

        /// <summary>
        /// Creates a <see cref="SpriteRenderer"/>
        /// </summary>
        /// <param name="sprite">The <see cref="Sprite"/> to render</param>
        /// <param name="color">The color of the <see cref="Sprite"/></param>
        public SpriteRenderer(Sprite sprite, Color color) {
            this.sprite = sprite;
            spriteColor = color;
        }

        public override void Render() {
            Rectangle sourceRect = sprite.sourceRect; // Gets the rect of the sprite

            // Draws the sprite
            EngineGlobals.SPRITE_BATCH.Draw(sprite.sheet.rawTexture, gameObject.transform.position, sourceRect, spriteColor, gameObject.transform.rotation, new Vector2(sourceRect.Width / 2, sourceRect.Height / 2), gameObject.transform.scale, SpriteEffects.None, 0f);
        }

    }
}
