using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FlappyBirdDemo.Managers
{
    public class InputManager
    {
        private KeyboardState _oldKS;
        private KeyboardState _KS;
        public InputManager()
        {
            Statics.INPUT = this;
        }

        public void Update()
        {
            if (_oldKS != null)
                _oldKS = _KS;

            _KS = Keyboard.GetState();
        }

        public bool IsKeyPressed(Keys k)
        {
            return (_KS.IsKeyDown(k) && _oldKS.IsKeyUp(k));
        }

        public bool IsKeyRelease(Keys k)
        {
            return (_KS.IsKeyDown(k) && _oldKS.IsKeyUp(k));
        }

        public KeyboardState CurentState()
        {
            return this._KS;
        }
    }
}
