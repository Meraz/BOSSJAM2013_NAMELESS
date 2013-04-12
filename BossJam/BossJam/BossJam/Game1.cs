using System;
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
        Player mPlayer = new Player();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            mScreenHandler = new ScreenHandler();
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            mScreenHandler.Initialize(Content);
            TextureHandler.GetTextureHandler().Initialize(Content);
            AudioHandler.GetAudioHandler().Initialize(Content);
            mPlayer.Initialize();
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

            mPlayer.Update(gameTime);
             

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            mPlayer.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
