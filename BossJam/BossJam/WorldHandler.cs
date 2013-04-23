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
        int mCurrentEnd = 0;

        private Camera mCamera;
        List<GameObject> mWorldEndless;
        List<Sprite> mSprite;

        private EnemyHandler mEH = new EnemyHandler(20);

        public WorldHandler()
        {
            mWorldEndless = new List<GameObject>();
            mSprite = new List<Sprite>();
        }

        public void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            mContentManager = lContentManager;
            mGraphicsDevice = lGraphicsDevice;

            mCamera = new Camera(mGraphicsDevice.Viewport, new Rectangle(0, 0, WorldConstants.WorldSizeX * WorldConstants.TileSize, WorldConstants.WorldSizeY * WorldConstants.TileSize));

            CreateTree();
            mCamera = new Camera(mGraphicsDevice.Viewport, new Rectangle(0, 0, WorldConstants.WorldSizeX * WorldConstants.TileSize, WorldConstants.WorldSizeY * WorldConstants.TileSize));
            mEH.Initialize();
            CreateWorld();
        }

        private void CreateTree()
        {
            Random r = new Random(5);
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(0, 2350 - 563)));
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(1500, 2350 - 563)));
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(3000, 2350 - 563)));
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(4500, 2350 - 563)));
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(6000, 2350 - 563)));
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(7500, 2350 - 563)));
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(9000, 2350 - 563)));
            mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.HIMMEL), new Vector2(10500, 2350 - 563)));
            for (int i = 8; i < 28; i++)
            {
                mSprite.Add(new Sprite(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.Träd2), new Vector2(r.Next(800, 14000), 1850), 0.5f));
            }

        }

        private void CreateWorld()
        {
            for (int i = 0; i < 450; i++)
            {
                mWorldEndless.Add(new TileObject());
                mWorldEndless.ElementAt(i).Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.JORD), new Vector2(mCurrentEnd + 50 * i, 2350));
            }
            for (int i = 450; i < 900; i++)
            {
                mWorldEndless.Add(new TileObject());
                mWorldEndless.ElementAt(i).Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.METALL), new Vector2(mCurrentEnd + 50 * (i - 450), 2400));
            }
            for (int i = 900; i < 1350; i++)
            {
                mWorldEndless.Add(new TileObject());
                mWorldEndless.ElementAt(i).Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.METALL), new Vector2(mCurrentEnd + 50 * (i - 900), 2450));
            }
        }

        private void ChangePositionOnEntities()
        {
            Vector2 lVector = Player.GetPlayer().GetPos();
            lVector.X -= 16000;
            Player.GetPlayer().SetPosition(lVector);
        }
        
        public void Update(GameTime lGameTime)
        {
            mCamera.Update(lGameTime);
            Player.GetPlayer().UpdateInfo(lGameTime);
            if (Player.GetPlayer().GetPos().X >= 50 * 350)
                ChangePositionOnEntities();

            Vector2 lPos = Player.GetPlayer().GetPos();
            int x = ((int)lPos.X + (WorldConstants.TileSize/2)) / WorldConstants.TileSize;
            int y = ((int)lPos.Y + (WorldConstants.TileSize/2)) / WorldConstants.TileSize;
            
            
              for (int i = 0; i < 1350; i++)
            {
                CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorldEndless.ElementAt(i), lGameTime);
            }

            //if (y + 1 >= 0 && y + 1 < WorldConstants.WorldSizeY)
            //    CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[x, y + 1], lGameTime);   //Down

            //if (x + 1 >= 0 && x + 1 < WorldConstants.WorldSizeX)
            //    CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[x + 1, y], lGameTime);         //Right

            //if (y - 1 >= 0 && y - 1 < WorldConstants.WorldSizeY)
            //    CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[x, y - 1], lGameTime);         //Up
            //if (x - 1 >= 0 && x + 1 < WorldConstants.WorldSizeX)
            //    CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[x - 1, y], lGameTime);         //Left

            //if (x - 1 >= 0 && x - 1 < WorldConstants.WorldSizeX &&
            //   y + 1 >= 0 && y + 1 < WorldConstants.WorldSizeY)
            //    CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[x - 1, y + 1], lGameTime);     //Downleft

            //if (x + 1 >= 0 && x + 1 < WorldConstants.WorldSizeX &&
            //   y + 1 >= 0 && y + 1 < WorldConstants.WorldSizeY)
            //    CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[x + 1, y + 1], lGameTime);     //DownRight

            //if (x + 1 >= 0 && x + 1 < WorldConstants.WorldSizeX &&
            //   y - 1 >= 0 && y - 1 < WorldConstants.WorldSizeY)
            //    CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorld[x + 1, y - 1], lGameTime); //UpRight
            mEH.Update(lGameTime);
            Player.GetPlayer().Update(lGameTime);
            Player.GetPlayer().Update(lGameTime);

        }
        public void Draw(SpriteBatch lSpriteBatch)
        {
            lSpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, mCamera.GetViewMatrix());
            for (int i = 0; i < 28; i++)

            for (int y = 0; y < WorldConstants.WorldSizeY; y++)
            {
                mSprite.ElementAt(i).Draw(lSpriteBatch);
            }
            for (int i = 0; i < 1350; i++)
            {
                mWorldEndless.ElementAt(i).Draw(lSpriteBatch);
            }

            Player.GetPlayer().Draw(lSpriteBatch);
            mEH.Draw(lSpriteBatch);
            Player.GetPlayer().Draw(lSpriteBatch);
            lSpriteBatch.End();
        }
    }
}
