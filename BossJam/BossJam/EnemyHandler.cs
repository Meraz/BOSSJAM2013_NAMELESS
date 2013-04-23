using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BossJam
{
    class EnemyHandler
    {
        private List<AbstractEnemy> mTypes = new List<AbstractEnemy>();
        private List<AbstractEnemy> mEnemies = new List<AbstractEnemy>();
        private Random mGenerator = new Random();
        private int mEnemyCount;

        public EnemyHandler(int enemyCount)
        {
            mTypes.Add(new BearTrapBrain());
            mTypes.Add(new Neuron());
            mEnemyCount = enemyCount;
        }

        public void Initialize()
        {
            Vector2 lPos;
            for (int i = 0; i < mEnemyCount; i++)
            {
                RandomizeEnemy();
                lPos.X = mGenerator.Next(1000+5000) + Player.GetPlayer().GetPos().X;
                if (mEnemies.ElementAt(i) is BearTrapBrain)
                {
                    lPos.Y = Player.GetPlayer().GetPos().Y;
                    mEnemies.ElementAt(i).Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.BEARTRAP), lPos);
                }
                else if (mEnemies.ElementAt(i) is Neuron)
                {
                    lPos.Y = 500 + Player.GetPlayer().GetPos().Y;
                    mEnemies.ElementAt(i).Initialize(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.NEURON), lPos);
                }
            }
        }

        public void Update(GameTime lGameTime)
        {
            for (int i = 0; i < mEnemies.Count; i++)
            {
                mEnemies.ElementAt(i).Update(lGameTime);
            }
            if (mGenerator.Next(200) == 42)
            {
                mEnemies.RemoveAt(mGenerator.Next(mEnemies.Count));
                RandomizeEnemy();
                Console.WriteLine("Enemy killed!");
            }
        }

        public void Draw(SpriteBatch lSpriteBatch)
        {
            for (int i = 0; i < mEnemies.Count; i++)
            {
                mEnemies.ElementAt(i).Draw(lSpriteBatch);
            }
        }

        private void RandomizeEnemy()
        {
            if (mGenerator.Next(10) <= 2)
                mEnemies.Add(mTypes.ElementAt(0));
            else
                mEnemies.Add(mTypes.ElementAt(1));
        }
    }
}
