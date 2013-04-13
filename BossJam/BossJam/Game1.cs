﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BossJam
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenHandler mScreenHandler;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            mScreenHandler = new ScreenHandler();
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1024;
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            TextureHandler.GetTextureHandler().Initialize(Content);
            AudioHandler.GetAudioHandler().Initialize(Content);
            
            mScreenHandler.Initialize(Content, GraphicsDevice);


        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            ScreenHandler.ScreenState lScreenState = mScreenHandler.Update(gameTime);
            if (lScreenState == ScreenHandler.ScreenState.Shutdown)
            {
                this.Exit();
            }
            if (lScreenState == ScreenHandler.ScreenState.Restart)
            {
                this.Exit(); //Add restart method
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mScreenHandler.Draw(spriteBatch);




            base.Draw(gameTime);
        }
    }
}
