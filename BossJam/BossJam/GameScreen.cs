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
    class GameScreen : AbstractScreen
    {        
        private WorldHandler mWorldHandler;
        private RenderTarget2D mRenderTarget;
        private Texture2D mUITexture;
        private SpriteFont spriteFont;
        private Color mHealthColor;

        //REMOVE LATER
        float health;
        string dialog;

        public GameScreen()
        {
            mWorldHandler = new WorldHandler();
        }

        public override void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            base.Initialize(lContentManager, lGraphicsDevice);
            mWorldHandler.Initialize(lContentManager, mGraphicsDevice);

            mRenderTarget = new RenderTarget2D(mGraphicsDevice, 1024, 768-75-130);
            mUITexture = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.UI);
            spriteFont = lContentManager.Load<SpriteFont>("spriteFont1");
            mHealthColor = new Color(0, 0, 0);


            //REMOVE LATER
            health = 100;
            dialog = " LOOK A LONG STRING OF TEXT AND STUFF";
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
            mWorldHandler.Update(lGameTime);

            //REMOVE LATER
            health -= 0.1f;
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            mGraphicsDevice.SetRenderTarget(mRenderTarget);
            mGraphicsDevice.Clear(Color.CornflowerBlue);

            mWorldHandler.Draw(lSpriteBatch);
            mGraphicsDevice.SetRenderTarget(null);
            mGraphicsDevice.Clear(Color.Black);

            //Render rendertarget
            lSpriteBatch.Begin();
            lSpriteBatch.Draw(mRenderTarget, new Vector2(0, 75), Color.White);
            lSpriteBatch.End();


            lSpriteBatch.Begin();
            //Health color change
            if (health > 10)
            {
                mHealthColor.R = (byte)(255 - 2.5f * health + 20);
                mHealthColor.G = (byte)(2.5 * health - 20);
            }

            //lSpriteBatch.Draw(mUITexture, new Rectangle(0, 0, 1024, 768), null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);

            lSpriteBatch.DrawString(spriteFont, "Health: " + (int)health,new Vector2(305,20), mHealthColor);

            lSpriteBatch.DrawString(spriteFont, "Crit chance: 100%", new Vector2(500, 20), Color.GhostWhite);


            lSpriteBatch.DrawString(spriteFont, "" + dialog, new Vector2(305, 660), Color.GhostWhite);
            lSpriteBatch.DrawString(spriteFont, "" + dialog, new Vector2(305, 680), Color.GhostWhite);
            lSpriteBatch.DrawString(spriteFont, "" + dialog, new Vector2(305, 700), Color.GhostWhite);

            //lSpriteBatch.DrawString(spriteFont, "Armor: 100", new Vector2(5, 10), Color.GhostWhite);

            lSpriteBatch.End();
        }
    }
}
