using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BossJam
{
    abstract class AnimatedObj : GameObject
    {
        protected float mSpeed;
        protected float mAcc;
        protected Vector2 mDir;
        protected int mHealth;
        protected int mDmg;

        protected int mMaxAnim; // Antalet rutor per animerat objekt
        protected int mCurrAnim = 0;
        protected Point mAnimDims;

        public AnimatedObj()
        {
            mSpeed = 0.0f;
            mAcc = 0.0f;
            mDir = new Vector2(0.0f, 0.0f);
            mHealth = 0;
            mDmg = 0;
        }

        public override void Initialize(Texture2D lTex, Vector2 lPos)
        {
            base.Initialize(lTex, lPos);
            if (mMaxAnim > 0)
            {
                mAnimDims.X = mTex.Width / mMaxAnim;
            }
            mAnimDims.Y = mTex.Height;
            //mRect = new Rectangle((int)mPos.X, (int)mPos.Y, mAnimDims.X, mAnimDims.Y);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
            Move(lGameTime);
            Attack();
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            base.Draw(lSpriteBatch);
        }

        protected abstract void Move(GameTime lGameTime);


        protected abstract void Attack();
    }
}
