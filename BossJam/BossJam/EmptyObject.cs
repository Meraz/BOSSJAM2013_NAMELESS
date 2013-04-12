using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BossJam
{
    class EmptyProject : GameObject
    {

        public EmptyProject()
        {
        }

        public override void Initialize(Texture2D lTex, Vector2 lPos)
        {
            //base.Initialize(lTex, lPos);
        }

        public override void Update(GameTime lGameTime)
        {
            //Empty
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            //Empty
        }
    }
}
