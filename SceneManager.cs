using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class SceneManager {

        public static Dictionary<string, Scene> SCENES = new Dictionary<string, Scene>();
        public static string CURRENT_SCENE = "NULL";

        public static void Tick() {
            if(CURRENT_SCENE != "NULL") {
                SCENES[CURRENT_SCENE].Tick();
            }
        }

        public static void Render() {
            if (CURRENT_SCENE != "NULL") {
                SCENES[CURRENT_SCENE].Render();
            }
        }

        public static void RenderUI() {
            if (CURRENT_SCENE != "NULL") {
                SCENES[CURRENT_SCENE].RenderUI();
            }
        }

    }
}
