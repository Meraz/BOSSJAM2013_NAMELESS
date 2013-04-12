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

        Vector2 mOldMousePos;
        double mRotation;

        public static Player GetPlayer()
        {
            return mPlayer;
        }

        private Player()
        {
            mHealth = 100;
            mSpeed = 4.0f;
            mDmg = 10;
            mDir = new Vector2(0,0);
            mPlayerGravity = 0.01f;
            mPlayerState = PlayerState.GROUND;

            mOldMousePos.X = Mouse.GetState().X;
            mOldMousePos.Y = Mouse.GetState().Y;

            CalcRotation();
        }

        public Vector2 GetPos()
        {
            return mPos;
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

            if (mOldMousePos.X != Mouse.GetState().X || mOldMousePos.X != Mouse.GetState().Y)
            {
                CalcRotation();
            }

            mPV.Draw(lSpriteBatch, mRect, (float)mRotation);
        }

        protected override void Move()
        {
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

        private void CalcRotation()
        {
            double xLength = mPos.X - Mouse.GetState().X;
            double yLength = mPos.Y - Mouse.GetState().Y;

            double xSquared = Math.Pow(xLength, 2);
            double ySquared = Math.Pow(yLength, 2);

            double totLength = Math.Sqrt(xSquared + ySquared);

            mRotation = Math.Asin(yLength / totLength);
        }
    }
}
