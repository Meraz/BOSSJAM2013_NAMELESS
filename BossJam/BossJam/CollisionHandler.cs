using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;



namespace BossJam
{
    class CollisionHandler
    {
        private CollisionHandler() { }
        static private CollisionHandler mCollisionHandler = new CollisionHandler();

        //Public Functions
        public static CollisionHandler GetCollisionHandler()
        {
            return mCollisionHandler;
        }

        public int CheckCollision(Player lPlayer, GameObject lOtherObject, GameTime lGameTime)
        {
            int r = 0;

            int result = AABBCollision(lPlayer, lOtherObject, lGameTime);
            if (result == 0)
                return 0;

            if (result == 1)
            {
                float aWHS = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.PLAYER).Height;	//Whole Heigth Size
                float aWWS = TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.PLAYER).Width;    //Whole Width Size
                Vector2 a = lPlayer.GetNextPosition(lGameTime);
                Vector2 aTopLeft = new Vector2(a.X, a.Y);	//TopLeft
                Vector2 aTopRight = new Vector2(a.X + aWWS, a.Y);	//TopRight
                Vector2 aBotRight = new Vector2(a.X + aWWS, a.Y + aWHS);	//BotRight
                Vector2 aBotLeft = new Vector2(a.X, a.Y + aWHS);	//BotLeft

                Vector2 b = lOtherObject.GetPos();
                float WHS = 50; //Whole block size
                Vector2 bTopLeft = new Vector2(b.X, b.Y);	//TopLeft
                Vector2 bTopRight = new Vector2(b.X + WHS, b.Y);	//TopRight
                Vector2 bBotRight = new Vector2(b.X + WHS, b.Y + WHS);	//BotRight
                Vector2 bBotLeft = new Vector2(b.X, b.Y + WHS);	//BotLeft

                if (b.Y > a.Y && r == 0)
                {
                    if ((aTopLeft.X < bTopLeft.X && bTopLeft.X < aBotRight.X) ||		//is it a floor?
                    (aTopLeft.X < bBotRight.X && bBotRight.X < aBotRight.X) ||
                    (aTopLeft.X < b.X && b.X < aBotRight.X))
                    {
                        if (bBotRight.X - aTopLeft.X < 0.02)
                            r = 0;
                        else if (aBotRight.X - bTopLeft.X < 0.02)
                            r = 0;
                        else
                        {
                            lPlayer.HitBot();
                        }
                    }
                }
                if (b.Y < a.Y && r == 0)		//This block is below us. (Player has lesser Y-value)	
                {
                    if ((aTopLeft.X < bTopLeft.X && bTopLeft.X < aBotRight.X) ||		//is it a roof?
                    (aTopLeft.X < bBotRight.X && bBotRight.X < aBotRight.X) ||
                    (aTopLeft.X < b.X && b.X < aBotRight.X))
                    {
                        if (bBotRight.X - aTopLeft.X < 0.02)
                            r = 0;
                        else if (aBotRight.X - bTopLeft.X < 0.02)
                            r = 0;
                        else
                        {
                            lPlayer.HitTop();
                        }
                    }
                }
                if (b.X < a.X && r == 0)		//This block is to the left of us. (Player has greater X-Value)
                {
                    if ((aBotRight.Y > bTopLeft.Y && bTopLeft.Y > aTopLeft.Y) ||
                       (aBotRight.Y > bBotRight.Y && bBotRight.Y > aTopLeft.Y) ||
                       (aBotRight.Y > b.Y && b.Y > aTopLeft.Y))
                    {
                        lPlayer.HitLeft();
                    }
                }
                if (b.X > a.X && r== 0)		//This block is to the right of us. (Player hasa lesser X-Value)
                {
                    if ((aBotRight.Y > bTopLeft.Y && bTopLeft.Y > aTopLeft.Y) ||
                       (aBotRight.Y > bBotRight.Y && bBotRight.Y > aTopLeft.Y) ||
                       (aBotRight.Y > b.Y && b.Y > aTopLeft.Y))
                    {
                        lPlayer.HitRight();
                    }
                }
            }
            return r;
        }

        private int AABBCollision(Player lPlayer, GameObject lOtherObject, GameTime lGameTime)
        {
            Vector2 a = lPlayer.GetNextPosition(lGameTime);
            Vector2 b = lOtherObject.GetPos();
            if(Math.Abs(a.X-b.X) > (50))
                return 0;
            if (Math.Abs(a.Y - b.Y) > (50))
                return 0;

            return 1;
        }

        public bool IsColliding(Player a, GameObject b)
        {
            if (b.mTex == null)
                return false;
            Color[] bitsA = new Color[a.mTex.Width * a.mTex.Height];
            a.mTex.GetData(bitsA);
            Color[] bitsB = new Color[b.mTex.Width * b.mTex.Height];
            b.mTex.GetData(bitsB);
            int x1 = Math.Max(a.GetRect().X, b.GetRect().X);
            int x2 = Math.Max(a.GetRect().X + a.GetRect().Width, b.GetRect().Left + b.GetRect().Width);
            int y1 = Math.Min(a.GetRect().Y, b.GetRect().Right);
            int y2 = Math.Min(a.GetRect().Y + a.GetRect().Height, b.GetRect().Y + b.GetRect().Height);

            for (int y = y1; y < y2; ++y)
            {
                for (int x = x1; x < x2; ++x)
                {

                    int banan = (x - a.GetRect().X) + (y - a.GetRect().Y) * a.GetRect().Width;
                    Color mA = a.TextureColors[(x - a.GetRect().X) + (y - a.GetRect().Y) * a.GetRect().Width];
                    Color mB = b.TextureColors[(x - b.GetRect().X) + (y - b.GetRect().Y) * b.GetRect().Width];

                    if (mA.A != 0 && mB.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }     
    }
}
