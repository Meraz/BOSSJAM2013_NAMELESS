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

        public PlayerView()
        {
            mViewTexture = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.LAMP);

        }

        public void Draw(SpriteBatch sB, Rectangle playerPos, float rotation)
        {

            LampRect = new Rectangle(512, 384, mViewTexture.Width, mViewTexture.Height);

            sB.Draw(mViewTexture, LampRect, null, Color.White, rotation, new Vector2(mViewTexture.Width / 2, mViewTexture.Height / 2), SpriteEffects.None, 0.0f);


        }

    }
}
