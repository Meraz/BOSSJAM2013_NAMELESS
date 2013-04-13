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

        public AbstractEnemy()
        {
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
        }

        public void SetPlayerPos(Vector2 playerPos)
        {
            mPlayerPos = playerPos;
        }

        protected override void Move(GameTime lGameTime)
        {
            if (mPlayerPos.X > mPos.X)
                mPos.X += mSpeed;
            else
                mPos.X += mSpeed * -1;

            if (mPlayerPos.Y > mPos.Y)
                mPos.Y += mSpeed;
            else
                mPos.Y += mSpeed * -1;
        }
    }
}
