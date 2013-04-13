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
        protected int mMaxX;

        protected SpriteEffects mEffect = SpriteEffects.None;

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

            mMaxX = mTex.Width / mMaxAnim;
        }

        public override void Update(GameTime lGameTime)
        {
            Move(lGameTime);
            mRect.X = (int)mPos.X;
            mRect.Y = (int)mPos.Y;
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            base.Draw(lSpriteBatch);
        }

        protected abstract void Move(GameTime lGameTime);


        protected abstract void Attack();
    }
}
