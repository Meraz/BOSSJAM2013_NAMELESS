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
        public const float PlayerWidth = 100;
        public const float PlayerHeigth = 100;

        private float mJumpSpeed = 500;
        private const int MaxPlayerSpeed = 100;
        private float mPlayerGravity = 5;
        
        private PlayerState mPlayerState;
        private PlayerView mPV = new PlayerView();
        private bool mHitX;
        private bool mHitY;
        static private Player mPlayer = new Player();

        private int mPlayerAttackCooldown;

        Vector2 mOldMousePos;
        double mRotation;
        private bool mJumpAllowed;
        int dt;

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
            mJumpAllowed = true;


            mPlayerAttackCooldown = 0;
           // CalcRotation();
        }

        public Boolean Dead()
        {
            return mHealth <= 0;
        }

        public Vector2 GetPos()
        {
            return mPos;
        }

        public Vector2 GetDir()
        {
            return mDir;
        }

        public int GetHealth()
        {
            return mHealth;
        }

        public void Damage(int DMG)
        {
            mHealth += DMG;
        }       

        public override void Initialize(Texture2D lTex, Vector2 lPos)
        {
            base.Initialize(lTex, lPos);
            TextureColors = new Color[lTex.Width * lTex.Height]; //Antalet pixlar

            mTex.GetData(TextureColors);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
        }

        public void UpdateInfo(GameTime lGameTime)
        {
            dt = lGameTime.ElapsedGameTime.Milliseconds;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                mDir.X = -500.0f * (float)lGameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                mDir.X = 500.0f * (float)lGameTime.ElapsedGameTime.TotalSeconds;
            }
            else
                mDir.X = 0;

            if (mPlayerState == PlayerState.GROUND)
            {
                if (mJumpAllowed && Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    mDir.Y -= mJumpSpeed * (float)lGameTime.ElapsedGameTime.TotalSeconds;
                    mPlayerState = PlayerState.AIR;
                    mJumpAllowed = false;
                }
            }
            if (mPlayerState == PlayerState.AIR)
            {
                mDir.Y += mPlayerGravity * (float)lGameTime.ElapsedGameTime.TotalSeconds;
            }
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
            //if (mDir.X > -0.1f && mDir.X < 0.1f)
            //    mDir.X = 0;
            
            if (mHitX)
                mDir.X = 0;
            if (mHitY)
                mDir.Y = 0;           


            mPos.X += mDir.X;
            mPos.Y += mDir.Y;

            mHitX = false;
            mHitY = false;
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

        public void HitBot()
        {
            mHitY = true;
            mPlayerState = PlayerState.GROUND;
            mJumpAllowed = true;
            if (mDir.Y > 0)
                mDir.Y = 0;
        }

        public void HitTop()
        {
            mHitY = true;
        }

        public void HitLeft()
        {
            mHitX = true;

        }

        public void HitRight()
        {
            mHitX = true;
        }

        public Vector2 GetNextPosition(GameTime lGameTime)
        {
            Vector2 lVector;
            lVector = new Vector2(mPos.X, mPos.Y);
            lVector.X += mDir.X;
            lVector.Y += mDir.Y;
            return lVector; 
        }

        public void SetHealth(int Health)
        {
            mHealth += Health;
        }

        protected override void Attack()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.E) && mPlayerAttackCooldown == 0)
            {    
                mPlayerAttackCooldown++;
            }
            else if (mPlayerAttackCooldown != 0)
            {
                mPlayerAttackCooldown++;
            }


            if (mPlayerAttackCooldown == 50)
            {
                //check enemies list


            }
            else if (mPlayerAttackCooldown == 100)
            {
                mPlayerAttackCooldown = 0;
            }
         
        }
    }
}
