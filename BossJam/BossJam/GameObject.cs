using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BossJam
{
    static class GameObjectConstants
    {
        public const int X = 50;
        public const int Y = 50;
    }

    abstract class GameObject
    {
        public Color[] TextureColors { private set; get; } //Property som håller pixlarna
        protected Texture2D mTex;
        protected Vector2 mPos;
        protected Rectangle mRect;

        public Rectangle GetRect()
        {
            return mRect;
        }

        public Vector2 GetPos()
        {
            return mPos;
        }

        public GameObject()
        {
        }

        public virtual void Initialize(Texture2D lTex, Vector2 lPos)
        {
            mTex = lTex;
            mPos = lPos;
            mRect = new Rectangle((int)mPos.X, (int)mPos.Y, GameObjectConstants.X, GameObjectConstants.Y);
        }

        public virtual void Update(GameTime lGameTime)
        {
            mRect.X = (int)mPos.X;
            mRect.Y = (int)mPos.Y;
        }

        public virtual void Draw(SpriteBatch lSpriteBatch)
        {
            lSpriteBatch.Draw(mTex, mRect, Color.White);
        }
    }
}
