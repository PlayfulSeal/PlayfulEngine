using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayfulEngine {
    public class UIBase {

        public Vector2 position;

        public UIBase(Vector2 position) {
            this.position = position;
        }

        public virtual void Tick() {

        }

        public virtual void Render() {

        }
    }
}
