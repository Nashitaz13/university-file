using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    // This class will show the state of: health,missiles,engine torque
    class StatusPanel
    {
        protected Texture2D panelTex;
        protected Point frameSize;
        protected Texture2D missileGaugeTex;
        protected Texture2D lifeGaugeTex;

        protected float playerHealth;
        protected float maxPlayerHealth;

        protected float engineTorque;
        protected float maxEngineTorque;

        protected float missile1Progress;
        protected float missile2Progress;
        protected float maxMissileProgress;

        protected Rectangle window;
        protected Vector2 position;


        public StatusPanel(Texture2D panelTex, Texture2D lifeGauge, float maxHealth, Texture2D missileGauge, float maxMissileProgress, float maxEngineTorque, Rectangle window)
        {
            this.panelTex = panelTex;
            this.frameSize = new Point(panelTex.Width, panelTex.Height);

            this.lifeGaugeTex = lifeGauge;
            this.maxPlayerHealth = maxHealth;

            this.missileGaugeTex = missileGauge;
            this.maxMissileProgress = maxMissileProgress;

            this.maxEngineTorque = maxEngineTorque;

            this.window = window;
            position = new Vector2(0, window.Height);
        }

        public virtual void Update(GameTime gameTime, float playerHealth, float engineTorque, float missile1Progress, float missile2Progress)
        {
            // Make the panel pop from the bottom of the window
            if (position.Y > window.Height - frameSize.Y)
            {
                position.Y -= 0.8f;
            }

            this.playerHealth = playerHealth;
            this.missile1Progress = missile1Progress;
            this.missile2Progress = missile2Progress;
            this.engineTorque = engineTorque;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Missiles progrss
            spriteBatch.Draw(missileGaugeTex
               , new Vector2(3, (int)(position.Y + 27 - (missile1Progress * missileGaugeTex.Height) / maxMissileProgress) + 2)
               , Color.White);
            spriteBatch.Draw(missileGaugeTex
               , new Vector2(17, (int)(position.Y + 27 - (missile2Progress * missileGaugeTex.Height) / maxMissileProgress) + 2)
               , Color.White);

            // Three colors for life gauge : blue for normal , yellow for caution , red for danger
            Color lifeColor = Color.Blue;
            if (playerHealth <= 0.33f * maxPlayerHealth)
                lifeColor = Color.Red;
            else if (playerHealth <= 0.66f * maxPlayerHealth)
                lifeColor = Color.Yellow;

            spriteBatch.Draw(lifeGaugeTex, position + new Vector2(37, 11),
                new Rectangle(0, 0, (int)((playerHealth * lifeGaugeTex.Width) / maxPlayerHealth), (int)lifeGaugeTex.Height), lifeColor);

            // Three colors for engine torque : min/mid/max speed
            Color engineTorqueColor = Color.Red;
            if (engineTorque <= 0.33f * maxEngineTorque)
                engineTorqueColor = Color.Blue;
            else if (engineTorque <= 0.66f * maxEngineTorque)
                engineTorqueColor = Color.Yellow;

            spriteBatch.Draw(lifeGaugeTex, position + new Vector2(35, 22),
                new Rectangle(0, 0, (int)((engineTorque * lifeGaugeTex.Width) / maxEngineTorque), 2), engineTorqueColor);

            spriteBatch.Draw(panelTex, position, Color.White);
        }
    }
}
