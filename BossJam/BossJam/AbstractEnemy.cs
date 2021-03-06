﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BossJam
{
    abstract class AbstractEnemy : AnimatedObj
    {
        protected Vector2 mPlayerPos;
        int cD;

        public AbstractEnemy()
        {
            mMaxAnim = 46;
        }

        public override void Initialize(Texture2D lTex, Vector2 lPos)
        {
            base.Initialize(lTex, lPos);
            cD = 0;
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            if (mCurrAnim == mMaxAnim)
            {
                mCurrAnim = 0;
            }
            mCurrAnim++;
            if (this is BearTrapBrain)
            {
                if (mEffect == SpriteEffects.FlipHorizontally)
                {
                    mEffect = SpriteEffects.None;
                }
                else if (mEffect == SpriteEffects.None)
                {
                    mEffect = SpriteEffects.FlipHorizontally;
                }
            }
            lSpriteBatch.Draw(mTex, mPos, new Rectangle((mTex.Width / mMaxAnim) * mCurrAnim, 0, mTex.Width / mMaxAnim, mTex.Height), Color.White, 0f, Vector2.Zero, 1.0f, mEffect, 0f);
        }

        protected override void Move(GameTime lGameTime)
        {
            if (Vector2.Distance(mPos, Player.GetPlayer().GetPos()) > 20.0f)
            {
                if (Player.GetPlayer().GetPos().X > mPos.X)
                {
                    mPos.X += mSpeed * lGameTime.ElapsedGameTime.Milliseconds;
                    mEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    mPos.X += mSpeed * -1 * lGameTime.ElapsedGameTime.Milliseconds;
                    mEffect = SpriteEffects.None;
                }

                if (Player.GetPlayer().GetPos().Y < mPos.Y)
                    mPos.Y += mSpeed * lGameTime.ElapsedGameTime.Milliseconds;
                else
                    mPos.Y += mSpeed * -1 * lGameTime.ElapsedGameTime.Milliseconds;
            }
        }


        protected override void Attack()
        {
            if (Vector2.Distance(mPos, Player.GetPlayer().GetPos()) < 50.0f && cD == 0)
            {
                cD++;
            }
            else if (Vector2.Distance(mPos, Player.GetPlayer().GetPos()) < 50.0f && cD == 50)
            {
                Player.GetPlayer().SetHealth(-mDmg);
            }
            else if (cD == 100)
            {
                cD = 0;
            }
            if (cD > 0)
            {
                cD++;
            }

        }
    }
}


