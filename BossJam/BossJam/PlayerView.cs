using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace BossJam
{
    class PlayerView
    {
        private Texture2D mViewTexture;
        private Rectangle LampRect;
        List<float> xThing = new List<float>();
        List<float> yThing = new List<float>();
        Random rand = new Random();

        public PlayerView()
        {
            mViewTexture = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.LAMP);

            for (int i = 0; i < 1500; i++)
            {
                xThing.Add(rand.Next(1000));
                yThing.Add(1000 - rand.Next(1000));
            }
        }

        public void Draw(SpriteBatch sB, Rectangle playerPos, float rotation)
        {
            for (int i = 0; i < 1500; i++)
            {
                xThing[i] += (rand.Next(13));
                yThing[i] -= (rand.Next(13));
                if (yThing[i] > 500 || xThing[i] > 500)
                {
                    yThing[i] = (rand.Next(300)) + 100;
                    xThing[i] = rand.Next(900) - 700;
                }
            }
            LampRect = new Rectangle((int)Player.GetPlayer().GetPos().X, (int)Player.GetPlayer().GetPos().Y, mViewTexture.Width, mViewTexture.Height);

            sB.Draw(mViewTexture, LampRect, null, Color.White, rotation, new Vector2(mViewTexture.Width / 2, mViewTexture.Height / 2), SpriteEffects.None, 0.0f);


            for (int i = 0; i < 400; i++)
            {
                sB.Draw(mViewTexture, new Rectangle((int)Player.GetPlayer().GetPos().X - (int)xThing[i], (int)Player.GetPlayer().GetPos().Y - (int)yThing[i], 2, 10), null, Color.Red, 0.5f, new Vector2(mViewTexture.Width / 2, mViewTexture.Height / 2), SpriteEffects.None, 0.0f);
            }

        }

    }
}



