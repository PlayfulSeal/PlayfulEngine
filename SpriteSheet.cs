using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlayfulEngine {
    public class SpriteSheet {
        public Texture2D rawTexture;

        public SpriteSheet(Texture2D sheet) {
            rawTexture = sheet;
        }

        public SpriteSheet(string path) {
            FileStream stream = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/{GameManager.COMPANY_NAME}/{GameManager.GAME_NAME}/Assets/{path}.png", FileMode.Open);
            rawTexture = Texture2D.FromStream(EngineGlobals.GRAPHICS_DEVICE_MANAGER.GraphicsDevice, stream);
            stream.Dispose();
        }
    }
}
