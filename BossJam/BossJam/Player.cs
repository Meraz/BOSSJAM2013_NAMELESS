using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BossJam
{
    sealed class Player : AnimatedObj
    {
        public enum PlayerState //Must be public to allow outside use
        {
            GROUND,
            AIR
        };

        private float mPlayerGravity;
        private PlayerState mPlayerState;
        private PlayerView mPV = new PlayerView();
        static private Player mPlayer = new Player();

        public static Player GetPlayer()
        {
            return mPlayer;
        }

        private Player()
        {
            mHealth = 100;
            mSpeed = 0.5f;
            mDmg = 10;
            mDir = new Vector2(0,0);
            mPlayerGravity = 0.01f;
            mPlayerState = PlayerState.GROUND;
        }

        public Vector2 GetPos()
        {
            return mPos;
        }

        public Vector2 GetDir()
        {
            return mDir;
        }

        public override void Initialize(Texture2D lTex, Vector2 lPos)
        {
            base.Initialize(lTex, lPos);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            base.Draw(lSpriteBatch);

            if(mDir.X < 0)
                mPV.Draw(lSpriteBatch, mRect, (float)Math.PI);
            else
                mPV.Draw(lSpriteBatch, mRect, 0.0f);
        }

        protected override void Move(GameTime lGameTime)
        {
            if (mPlayerState == PlayerState.AIR)
            {
                mDir.Y += mPlayerGravity;
            }

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

            mPos += mDir * mSpeed * lGameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
