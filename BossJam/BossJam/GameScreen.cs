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


        public GameScreen()
        {
            mWorldHandler = new WorldHandler();
        }

        public override void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            base.Initialize(lContentManager, lGraphicsDevice);
            mWorldHandler.Initialize(lContentManager, mGraphicsDevice);
            mRenderTarget = new RenderTarget2D(mGraphicsDevice, 1024, 768-75-130);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
            mWorldHandler.Update(lGameTime);
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            mGraphicsDevice.SetRenderTarget(mRenderTarget);
            mGraphicsDevice.Clear(Color.CornflowerBlue);

            mWorldHandler.Draw(lSpriteBatch);
            mGraphicsDevice.SetRenderTarget(null);
            mGraphicsDevice.Clear(Color.Black);

            lSpriteBatch.Begin();
            lSpriteBatch.Draw(mRenderTarget, new Vector2(0, 75), Color.White);
            lSpriteBatch.End();
        }
    }
}
