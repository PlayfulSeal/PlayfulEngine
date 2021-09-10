using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine.UI {
    /// <summary>
    /// Renders a <see cref="Sprite"/> to the screen
    /// </summary>
    public class UISprite : UIBase {

        /// <summary>
        /// The <see cref="Sprite"/> to render
        /// </summary>
        public Sprite sprite;

        /// <summary>
        /// The scale of the <see cref="Sprite"/>
        /// </summary>
        public Vector2 scale = Vector2.One;

        /// <summary>
        /// The rotation of the <see cref="Sprite"/>
        /// </summary>
        public float rotation = 0f;

        /// <summary>
        /// Creates a new <see cref="UISprite"/>
        /// </summary>
        /// <param name="sprite">The <see cref="Sprite"/> to render</param>
        /// <param name="position">The position of the <see cref="Sprite"/></param>
        public UISprite(Sprite sprite, Vector2 position) : base(position) {
            this.sprite = sprite;
        }

        /// <summary>
        /// Creates a new <see cref="UISprite"/>
        /// </summary>
        /// <param name="sprite">The <see cref="Sprite"/> to render</param>
        /// <param name="position">The position of the <see cref="Sprite"/></param>
        /// <param name="scale">The scale of the <see cref="Sprite"/></param>
        public UISprite(Sprite sprite, Vector2 position, Vector2 scale) : base(position) {
            this.sprite = sprite;
            this.scale = scale;
        }

        /// <summary>
        /// Creates a new <see cref="UISprite"/>
        /// </summary>
        /// <param name="sprite">The <see cref="Sprite"/> to render</param>
        /// <param name="position">The position of the <see cref="Sprite"/></param>
        /// <param name="scale">The scale of the <see cref="Sprite"/></param>
        /// <param name="rotation">The rotation of the <see cref="Sprite"/></param>
        public UISprite(Sprite sprite, Vector2 position, Vector2 scale, float rotation) : base(position) {
            this.sprite = sprite;
            this.scale = scale;
            this.rotation = rotation;
        }

        public override void Render() {

            // Render the sprite
            EngineGlobals.SPRITE_BATCH.Draw(sprite.sheet.rawTexture, position, sprite.sourceRect, Color.White, rotation, new Vector2(sprite.sourceRect.Width / 2, sprite.sourceRect.Height / 2), scale, SpriteEffects.None, 0f);
        }

    }
}
