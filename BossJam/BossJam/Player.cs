using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BossJam
{
    class Player : AnimatedObj
    {

        public Player()
        {
            mHealth = 100;
            mSpeed = 2.0f;
            mDmg = 10;
        }

        public void Initialize()
        {
            Vector2 lPos = new Vector2(1, 1);
            Texture2D lTex = TextureHandler.GetTextureHandler().GetTexture(0);
            base.Initialize(lTex, lPos);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
            Move();
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {

            base.Draw(lSpriteBatch);
        }

        protected override void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                mPos.Y += mSpeed * -1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                mPos.Y += mSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                mPos.X += mSpeed * -1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                mPos.X += mSpeed;
            }
        }
    }
}
