using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class Scene {
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<UIBase> UI = new List<UIBase>();

        public void Tick() {
            foreach(GameObject obj in gameObjects) {
                obj.Tick();
            }

            foreach (UIBase _ui in UI) {
                _ui.Tick();
            }
        }

        public void Render() {
            foreach (GameObject obj in gameObjects) {
                obj.Render();
            }

           
        }

        public void RenderUI() {
            foreach (UIBase _ui in UI) {
                _ui.Render();
            }
        }
    }
}
