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
        }

        public void Initialize()
        {
            Vector2 lPos = new Vector2(1, 1);
            Texture2D lTex = TextureHandler.GetTextureHandler().GetTexture(0);
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

        protected override void Move()
        {
        }
    }
}
