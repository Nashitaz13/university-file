using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
///
/// XNA_RPG textMapEditor engine được viết bởi HuyetSat - Xvna.forumb.biz
/// Mọi cập nhật hay thắc mắc ý kiến về engine xin liên hệ tại: xvna.forumb.biz hoặc thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các bạn phát triển được RPG một cách dễ dàng!
/// Chân thành cảm ơn bạn đã quan tâm sử dụng engine này!
///
namespace XNA_RPG_textMapEditor.Helper
{
    class Input
    {
        KeyboardState keyBoard ;
        KeyboardState lastKeyBoard = Keyboard.GetState();
        MouseState CurrentMouse;
        public void Update()
        {
            CurrentMouse = Mouse.GetState();
            lastKeyBoard = keyBoard;
            keyBoard = Keyboard.GetState();
        }
        public bool Press(Keys key)
        {
            return keyBoard.IsKeyDown(key);
        }
        public bool Release(Keys key)
        {
            return (keyBoard.IsKeyUp(key) && lastKeyBoard.IsKeyDown(key));
        }
        public bool MouseOver(Rectangle rec)
        {
            Vector2 point = new Vector2(CurrentMouse.X, CurrentMouse.Y);
            return (point.X >= rec.X) && (point.X <= rec.X + rec.Width) && (point.Y >= rec.Y) && (point.Y <= rec.Y + rec.Height);        
        }
        public bool LeftMouseClick()
        {
            return (CurrentMouse.LeftButton == ButtonState.Pressed);
        }
        public bool LeftMouseRelease()
        {
            return (CurrentMouse.LeftButton == ButtonState.Released);
        }
        public bool RightMouseClick()
        {
            return (CurrentMouse.RightButton == ButtonState.Pressed);
        }
        public bool RightMouseRelease()
        {
            return (CurrentMouse.RightButton == ButtonState.Released);
        }
    }
}
