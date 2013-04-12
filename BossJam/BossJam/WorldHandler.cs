using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;


namespace BossJam
{
    static class WorldConstants
    {
        public const int WorldSizeX = 50;
        public const int WorldSizeY = 50;
        public const int TileSize = 32;
    }


    class WorldHandler
    {
        private ContentManager mContentManager;
        private GraphicsDevice mGraphicsDevice;

        private Camera mCamera;
        //GameObject[][] mWorld;
        Texture2D a;

        public WorldHandler()
        {

            // mWorld = new GameObject[WorldSizeX][WorldSizeY];
        }

        public void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            mContentManager = lContentManager;
            mGraphicsDevice = lGraphicsDevice;
            mCamera = new Camera(mGraphicsDevice.Viewport, new Rectangle(0, 0, WorldConstants.WorldSizeX * WorldConstants.TileSize, WorldConstants.WorldSizeY * WorldConstants.TileSize));
            //a = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.A);

        }


        public void Update(GameTime lGameTime)
        {
            mCamera.Update(lGameTime);
        }

        public void Draw(SpriteBatch lSpriteBatch)
        {
            lSpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, mCamera.GetViewMatrix());

            lSpriteBatch.Draw(a, new Rectangle(0, 0, 500, 500), Color.White);
            lSpriteBatch.End();
        }
    }
}
