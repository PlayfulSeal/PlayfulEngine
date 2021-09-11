using FontStashSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlayfulEngine.UI {
    public class UIFonts {

        private static FontSystem FONT_SYSTEM = null;

        public static void CreateFont(string path) {
            if(FONT_SYSTEM == null) {
                FONT_SYSTEM = new FontSystem();
            }

            FONT_SYSTEM.AddFont(File.ReadAllBytes($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/{GameManager.COMPANY_NAME}/{GameManager.GAME_NAME}/Assets/Fonts/{path}.ttf"));
        }

        public static SpriteFontBase GetFont(int fontSize) {
            return FONT_SYSTEM.GetFont(fontSize);
        }

    }
}
