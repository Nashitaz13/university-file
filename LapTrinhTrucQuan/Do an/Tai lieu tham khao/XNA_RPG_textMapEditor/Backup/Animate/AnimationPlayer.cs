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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using XNA_RPG_textMapEditor.Core;
using XNA_RPG_textMapEditor.Controller;
using XNA_RPG_textMapEditor.Helper;

namespace XNA_RPG_textMapEditor.Animate
{
    struct AnimationPlayer
    {
        Animation animation;
        private float time;
        int frameIndex;
        #region property:Animation,FrameIndex,Origin,
        public Animation Animation
        {
            get { return animation; }
        }
        
        public int FrameIndex
        {
            get { return frameIndex; }
        }
        
        public Vector2 Origin
        {
            get { return new Vector2(Animation.FrameWidth / 2.0f, Animation.FrameHeight*6/9); }
        }
#endregion
        /// <summary>
        /// Begins or continues playback of an animation.
        /// </summary>
        public void PlayAnimation(Animation animation)
        {
            // If this animation is already running, do not restart it.
            if (Animation == animation)
                return;

            // Start the new animation.
            this.animation = animation;
            this.frameIndex = 0;
            this.time = 0.0f;
        }

        /// <summary>
        /// Advances the time position and draws the current frame of the animation.
        /// </summary>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
        {
            if (Animation == null)
            {
                return;
                throw new NotSupportedException("No animation is currently playing.");
                
            }

            // Process passing time.
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > Animation.FrameTime)
            {
                time -= Animation.FrameTime;

                // Advance the frame index; looping or clamping as appropriate.
                if (Animation.IsLooping)
                {
                    frameIndex = (frameIndex + 1) % Animation.FrameCount;
                }
                else
                {
                    frameIndex = Math.Min(frameIndex + 1, Animation.FrameCount - 1);
                }
            }

            // Calculate the source rectangle of the current frame.
            Rectangle source = new Rectangle(FrameIndex * Animation.Texture.Height, 0, Animation.Texture.Height, Animation.Texture.Height);

            // Draw the current frame.
            spriteBatch.Draw(Animation.Texture, position+new Vector2(25,25), source, Color.White, 0.0f, Origin, 1.0f, spriteEffects, 0.0f);
        }
    }
}
