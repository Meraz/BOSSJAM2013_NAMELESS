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
        bool randstuff;

        protected Vector2 mPlayerPos;
        int cD;
        protected double mAttackCooldown;
        protected double mLastAttack = 0.0f;
        public AbstractEnemy()
        {
            mMaxAnim = 46;
        }

        public override void Initialize(Texture2D lTex, Vector2 lPos)
        {
            base.Initialize(lTex, lPos);
            cD = 0;
            randstuff = true;
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            //base.Draw(lSpriteBatch);

            if (mCurrAnim == mMaxAnim-1)
            {
                mCurrAnim = 0;
            }
            mCurrAnim++;

                lSpriteBatch.Draw(mTex, mPos, new Rectangle((mTex.Width / mMaxAnim) * mCurrAnim, 0, mTex.Width / mMaxAnim, mTex.Height), Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
            
        }

        protected override void Move(GameTime lGameTime)
        {
            if (Vector2.Distance(mPos, Player.GetPlayer().GetPos()) > 20.0f)
            {
                if (Player.GetPlayer().GetPos().X > mPos.X)
                    mPos.X += mSpeed * lGameTime.ElapsedGameTime.Milliseconds;
                else
                    mPos.X += mSpeed * -1 * lGameTime.ElapsedGameTime.Milliseconds;

                if (Player.GetPlayer().GetPos().Y > mPos.Y)
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
