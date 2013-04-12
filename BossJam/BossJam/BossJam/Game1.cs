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
        float rot = 0.0f;
        Player mPlayer = new Player();

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
<<<<<<< HEAD
=======

            mPlayer.Update(gameTime);
             
>>>>>>> 5e7ec65a861c3f075135d79a8b3aeefeae773f91

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
<<<<<<< HEAD
            GraphicsDevice.Clear(Color.Red);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);

            Texture2D a = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.A);
            Texture2D b = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.B);

            Rectangle LampRect = new Rectangle(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2, a.Width, a.Height);


            spriteBatch.Draw(a, LampRect, null, Color.White, rot, new Vector2(a.Width / 2, a.Height / 2), SpriteEffects.None, 0.0f);


            spriteBatch.Draw(b, new Rectangle(0,0, b.Width, b.Height), Color.White);
           
=======
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            mPlayer.Draw(spriteBatch);
>>>>>>> 5e7ec65a861c3f075135d79a8b3aeefeae773f91
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
