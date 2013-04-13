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

        AbstractEnemy mNeuron = new Neuron();

        public WorldHandler()
        {
            mWorldEndless = new List<GameObject>();
            mSprite = new List<Sprite>();
        }

        public void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            mContentManager = lContentManager;
            mGraphicsDevice = lGraphicsDevice;

            mNeuron.Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.NEURON), new Vector2(100, 100));

            mCamera = new Camera(mGraphicsDevice.Viewport, new Rectangle(0, 0, WorldConstants.WorldSizeX * WorldConstants.TileSize, WorldConstants.WorldSizeY * WorldConstants.TileSize));
            mNeuron.Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.NEURON), new Vector2(50.0f, 50.0f));

            CreateTree();
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
            if (Player.GetPlayer().GetPos().X >= 50*350)
            {
                ChangePositionOnEntities();
            }

            for (int i = 0; i < 1350; i++)
            {
                CollisionHandler.GetCollisionHandler().CheckCollision(Player.GetPlayer(), mWorldEndless.ElementAt(i), lGameTime);
            }


            Player.GetPlayer().Update(lGameTime);

        }
        public void Draw(SpriteBatch lSpriteBatch)
        {
            lSpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, mCamera.GetViewMatrix());
            for (int i = 0; i < 28; i++)
            {
                mSprite.ElementAt(i).Draw(lSpriteBatch);
            }
            for (int i = 0; i < 1350; i++)
            {
                mWorldEndless.ElementAt(i).Draw(lSpriteBatch);
            }

            Player.GetPlayer().Draw(lSpriteBatch);
            mNeuron.Draw(lSpriteBatch);
            lSpriteBatch.End();
        }
    }
}
