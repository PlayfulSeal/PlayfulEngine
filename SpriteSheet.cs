using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class SpriteSheet {
        public Texture2D rawTexture;

        public SpriteSheet(Texture2D sheet) {
            rawTexture = sheet;
        }
    }
}
