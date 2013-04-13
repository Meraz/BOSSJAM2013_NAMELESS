using System;
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
        protected double mAttackCooldown;
        protected double mLastAttack = 0.0f;

        public AbstractEnemy()
        {
            mMaxAnim = 1;
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

            if (mCurrAnim == mMaxAnim)
                mCurrAnim = 0;
            else
                mCurrAnim++;

            lSpriteBatch.Draw(
                mTex,
                mPos,
                new Rectangle(
                    (int)mPos.X*mCurrAnim,
                    (int)mPos.Y,
                    mAnimDims.X,
                    mAnimDims.Y),
                 Color.White);
        }

        protected override void Move(GameTime lGameTime)
        {
            if (mPlayerPos.X > mPos.X)
                mPos.X += mSpeed * lGameTime.ElapsedGameTime.Milliseconds;
            else
                mPos.X += mSpeed * -1 * lGameTime.ElapsedGameTime.Milliseconds;

            if (mPlayerPos.Y > mPos.Y)
                mPos.Y += mSpeed * lGameTime.ElapsedGameTime.Milliseconds;
            else
                mPos.Y += mSpeed * -1 * lGameTime.ElapsedGameTime.Milliseconds;


            if (Vector2.Distance(mPos, mPlayerPos) < 50.0f)
            {
                //Attack function
            }
        }
    }
}
