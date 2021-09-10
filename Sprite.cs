using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class Sprite {
        public SpriteSheet sheet;
        public Rectangle sourceRect;

        public Sprite(SpriteSheet sheet, Rectangle sourceRect) {
            this.sheet = sheet;
            this.sourceRect = sourceRect;
        }
    }
}
