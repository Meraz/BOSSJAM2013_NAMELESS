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
            //spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);

            //Texture2D a = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.PLAYER);
            //Texture2D b = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.PLAYER);

            //Rectangle LampRect = new Rectangle(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2, a.Width, a.Height);


            //spriteBatch.Draw(a, LampRect, null, Color.White, rot, new Vector2(a.Width / 2, a.Height / 2), SpriteEffects.None, 0.0f);


            //spriteBatch.Draw(b, new Rectangle(0,0, b.Width, b.Height), Color.White);
           
            //GraphicsDevice.Clear(Color.Black);
            //spriteBatch.End();

            //spriteBatch.Begin();
            //mPlayer.Draw(spriteBatch);
            //spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
