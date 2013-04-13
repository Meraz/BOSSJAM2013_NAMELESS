using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace BossJam
{
    class TileObject : GameObject
    {

        public TileObject()
        {
        }

        public override void Initialize(Texture2D lTex, Vector2 lPos)
        {
            base.Initialize(lTex, lPos);
            TextureColors = new Color[lTex.Width * lTex.Height]; //Antalet pixlar

            mTex.GetData(TextureColors);
        }

        public override void Update(GameTime lGameTime)
        {
            //Empty
        }
    }
}
