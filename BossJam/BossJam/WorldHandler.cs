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


        Neuron firstNeuron = new Neuron();


        public WorldHandler()
        {
            mWorld = new GameObject[WorldConstants.WorldSizeX, WorldConstants.WorldSizeY];
        }

        public void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            mContentManager = lContentManager;
            mGraphicsDevice = lGraphicsDevice;

            firstNeuron.Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.NEURON), new Vector2(100, 100));

            mCamera = new Camera(mGraphicsDevice.Viewport, new Rectangle(0, 0, WorldConstants.WorldSizeX * WorldConstants.TileSize, WorldConstants.WorldSizeY * WorldConstants.TileSize));

            CreateWorld();
        }

        private void CreateWorld()
        {
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

            int a, b, c, d, e;
            Vector2 lPos = Player.GetPlayer().GetPos();
            int lPosX = ((int)lPos.X + (WorldConstants.TileSize/2)) / WorldConstants.TileSize;
            int lPosY = ((int)lPos.Y + (WorldConstants.TileSize/2)) / WorldConstants.TileSize;
                 
            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX-1,       lPosY+1]);
            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX-1,       lPosY]);
            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX-1,       lPosY-1]); //Left three

            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX,         lPosY+1);
            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX,         lPosY-1]);

            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX+1,       lPosY+1]);
            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX+1,       lPosY]);
            //CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[lPosX+1,       lPosY-1]); //Right three


            firstNeuron.Update(lGameTime);

            int aaaa;
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
            
            
            firstNeuron.Draw(lSpriteBatch);
            lSpriteBatch.End();

            
        }
    }
}
