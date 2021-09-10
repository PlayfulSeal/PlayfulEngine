using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlayfulEngine {
    public class UIInteractable : UIBase {

        public Rectangle rect;

        private bool _isHovering = false;
        private bool _hasClicked = false;

        public UIInteractable(Rectangle rect) : base(new Vector2(rect.X, rect.Y)) {
            this.rect = rect;
        }

        public virtual void OnEnter() {  }
        public virtual void OnLeave() {  }
        public virtual void OnClick() {  }
        public virtual void WhilePressed() {  }

        public override void Tick() {
            Rectangle mouseRect = new Rectangle(Mouse.GetState().Position, new Point(8, 8));

            if(mouseRect.Intersects(rect)) {
                if(!_isHovering) {
                    OnEnter();
                    _isHovering = true;
                }
            } else {
                if(_isHovering) {
                    OnLeave();
                    _isHovering = false;
                }
            }

            if(_isHovering && Mouse.GetState().LeftButton == ButtonState.Pressed) {
                if(_hasClicked) {
                    WhilePressed();
                } else {
                    OnClick();
                    _hasClicked = true;
                }
            } else {
                _hasClicked = false;
            }
        }

    }
}
