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
            AIR,
            JUMP
        };

        private const int MaxPLayerSpeed = 100;
        private float mJumpSpeed = 5;
        private float mPlayerGravity = 0.01f;
        
        private PlayerState mPlayerState;
        private PlayerView mPV = new PlayerView();
        private bool mHitX;
        private bool mHitY;
        static private Player mPlayer = new Player();
        


        Vector2 mOldMousePos;
        double mRotation;
        private bool mJumpAllowed;
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
            
            mPlayerState = PlayerState.GROUND;

            mOldMousePos.X = Mouse.GetState().X;
            mOldMousePos.Y = Mouse.GetState().Y;
            mHitX = false;
            mHitY = false;

           // CalcRotation();
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
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                mDir.X = -1 * lGameTime.ElapsedGameTime.Milliseconds;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                mDir.X = 1 * lGameTime.ElapsedGameTime.Milliseconds;
            }
            
            if (mPlayerState == PlayerState.AIR)
            {
                mDir.Y += mPlayerGravity;
            }

            if (mDir.X > 0)				//Röra sig mot noll
                mDir.X -= 0.2f * lGameTime.ElapsedGameTime.Milliseconds;
            else if (mDir.X < 0)
                mDir.X += 0.2f * lGameTime.ElapsedGameTime.Milliseconds;

            //if (mHitX)
            //    mDir.X = 0;
            //if (mHitY)
            //    mDir.Y = 0;

            //if (mDir.X > MaxPLayerSpeed)
            //    mDir.X = MaxPLayerSpeed;
            //if (mDir.X < 0)
            //    mDir.X = 0;

            if (mPlayerState == PlayerState.GROUND)
            {
                if (mJumpAllowed && Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    mDir.Y += mJumpSpeed*lGameTime.ElapsedGameTime.Milliseconds; 

                }

            }

            mPos.X += mDir.X;
            mPos.Y += mDir.Y;

            mHitX = false;
            mHitY = false;


            if (Keyboard.GetState().IsKeyDown(Keys.Space) && mPlayerState == PlayerState.GROUND)
            {
                mDir.Y = -1;
                mPlayerState = PlayerState.AIR;
            }
        }

        private void CalcRotation(GameTime lGameTime)
        {
            double xLength = mPos.X - Mouse.GetState().X;
            double yLength = mPos.Y - Mouse.GetState().Y;

            double xSquared = Math.Pow(xLength, 2);
            double ySquared = Math.Pow(yLength, 2);

            double totLength = Math.Sqrt(xSquared + ySquared);

            mRotation = Math.Asin(yLength / totLength);

            mPos += mDir * mSpeed * lGameTime.ElapsedGameTime.Milliseconds;

        }

        public void SetCollision()
        {

        }

        public void GetNextPosition(float dt)
        {
            Vector2 lVector;
           // lVector.X = mPos
        }
    }
}
