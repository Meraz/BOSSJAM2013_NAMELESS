using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BossJam
{
    class Neuron : AbstractEnemy
    {
        public Neuron()
        {
            mDmg = 2;
            mSpeed = 0.2f;
            mSpeed = 0.5f;
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
    }
}
