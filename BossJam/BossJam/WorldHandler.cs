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
        public const int TileSize = 50;
    }


    class WorldHandler
    {
        private ContentManager mContentManager;
        private GraphicsDevice mGraphicsDevice;

        private Camera mCamera;
        GameObject[,] mWorld;
        Texture2D a;

        public WorldHandler()
        {
            mWorld = new GameObject[WorldConstants.WorldSizeX, WorldConstants.WorldSizeY];
        }

        public void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            mContentManager = lContentManager;
            mGraphicsDevice = lGraphicsDevice;

            mCamera = new Camera(mGraphicsDevice.Viewport, new Rectangle(0, 0, WorldConstants.WorldSizeX * WorldConstants.TileSize, WorldConstants.WorldSizeY * WorldConstants.TileSize));

            for (int y = 0; y < WorldConstants.WorldSizeY; y++)
            {
                for (int x = 0; x < WorldConstants.WorldSizeX; x++)
                {
                    if (x == 0 || x == WorldConstants.WorldSizeX - 1 || y == 0 || y == WorldConstants.WorldSizeY - 1)
                        mWorld[x, y] = new TileObject();
                    else
                        mWorld[x, y] = new EmptyProject();
                    mWorld[x, y].Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.BLOCK), new Vector2(WorldConstants.TileSize * x, WorldConstants.TileSize * y));
                }
            }
        }
        
        public void Update(GameTime lGameTime)
        {
            mCamera.Update(lGameTime);
            Player.GetPlayer().Update(lGameTime);
        }

        public void Draw(SpriteBatch lSpriteBatch)
        {
            lSpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, mCamera.GetViewMatrix());
            Player.GetPlayer().Draw(lSpriteBatch);

            for (int y = 0; y < WorldConstants.WorldSizeY; y++)
            {
                for (int x = 0; x < WorldConstants.WorldSizeX; x++)
                {
                    mWorld[x, y].Draw(lSpriteBatch);
                }
            }
            lSpriteBatch.End();
        }
    }
}
