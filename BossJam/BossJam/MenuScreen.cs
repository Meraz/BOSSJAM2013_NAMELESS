﻿using System;
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
    class MenuScreen : AbstractScreen
    {
        public MenuScreen()
        {

        }

        public override void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            base.Initialize(lContentManager, lGraphicsDevice);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
            Console.WriteLine("MenuScreen"); 

        }
        
        public override void Draw(SpriteBatch lSpriteBatch)
        {

        }
    }
}
