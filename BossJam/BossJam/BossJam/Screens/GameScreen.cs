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
    class GameScreen : AbstractScreen
    {
        public GameScreen()
        {

        }

        public override void Initialize(ContentManager lContentManager)
        {
            base.Initialize(lContentManager);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
            Console.WriteLine("GameScreen"); 
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {

        }
    }
}