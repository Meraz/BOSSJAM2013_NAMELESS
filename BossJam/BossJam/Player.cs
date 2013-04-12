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
        private float mPlayerGravity;
        


        public enum PlayerState //Must be public to allow outside use
        {
            GROUND,
            AIR
        };


        private PlayerState mPlayerState;


        public Player()
        {
            mHealth = 100;
            mSpeed = 4.0f;
            mDmg = 10;
            mDir = new Vector2(0,0);
            mPlayerGravity = 0.01f;
            mPlayerState = PlayerState.GROUND;
        }

        public void Initialize()
        {
            Vector2 lPos = new Vector2(1, 300);
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
            
            
            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            //{
            //    mPos.Y += mSpeed * -1;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.S))
            //{
            //    mPos.Y += mSpeed;
            //}


            if (mPlayerState == PlayerState.AIR)
            {
                mDir.Y += mPlayerGravity;
            }


            mDir.X = 0;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                mDir.X = -1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                mDir.X = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && mPlayerState == PlayerState.GROUND)
            {
                mDir.Y = -1;
                mPlayerState = PlayerState.AIR;
            }


            mPos += mDir * mSpeed;

        }
    }
}
