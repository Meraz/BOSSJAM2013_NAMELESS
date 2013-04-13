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
                float aWHS = Player.PlayerHeigth;	//Whole Heigth Size
                float aWWS = Player.PlayerWidth ;    //Whole Width Size
                Vector2 a = lPlayer.GetPos();
                Vector2 aTopLeft = new Vector2(a.X - aWWS, a.Y + aWHS);	//TopLeft
                Vector2 aTopRight = new Vector2(a.X + aWWS, a.Y + aWHS);	//TopRight
                Vector2 aBotRight = new Vector2(a.X + aWWS, a.Y - aWHS);	//BotRight
                Vector2 aBotLeft = new Vector2(a.X - aWWS, a.Y - aWHS);	//BotLeft

                Vector2 b = lOtherObject.GetPos();
                float WHS = 50; //Whole block size
                Vector2 bTopLeft = new Vector2(b.X, b.Y);	//TopLeft
                Vector2 bTopRight = new Vector2(b.X + WHS, b.Y);	//TopRight
                Vector2 bBotRight = new Vector2(b.X + WHS, b.Y + WHS);	//BotRight
                Vector2 bBotLeft = new Vector2(b.X, b.Y + WHS);	//BotLeft


                //Vector2 a = lPlayer.GetPos();
                //Vector2 aTopLeft = new Vector2(a.X - aHWS, a.Y + aHHS);	//TopLeft
                //Vector2 aTopRight = new Vector2(a.X + aHWS, a.Y + aHHS);	//TopRight
                //Vector2 aBotRight = new Vector2(a.X + aHWS, a.Y - aHHS);	//BotRight
                //Vector2 aBotLeft = new Vector2(a.X - aHWS, a.Y - aHHS);	//BotLeft

                //Vector2 b = lOtherObject.GetPos();
                //float HBS = 25; //Half block size
                //Vector2 bTopLeft = new Vector2(b.X - HBS, b.Y + HBS);	//TopLeft
                //Vector2 bTopRight = new Vector2(b.X + HBS, b.Y + HBS);	//TopRight
                //Vector2 bBotRight = new Vector2(b.X + HBS, b.Y - HBS);	//BotRight
                //Vector2 bBotLeft = new Vector2(b.X - HBS, b.Y - HBS);	//BotLeft

                if (b.Y < a.Y && r == 0)
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
                            r = 1;
                        }
                    }
                }
                if (b.Y > a.Y && r == 0)		//This block is below us. (Player has lesser Y-value)	
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
                            r = 2;
                        }
                    }
                }
                if (b.X < a.X)		//This block is to the left of us. (Player has greater X-Value)
                {
                    if ((aBotRight.Y < bTopLeft.Y && bTopLeft.Y < aTopLeft.Y) ||
                       (aBotRight.Y < bBotRight.Y && bBotRight.Y < aTopLeft.Y) ||
                       (aBotRight.Y < b.Y && b.Y < aTopLeft.Y))
                    {
                        if (bTopLeft.Y - aBotRight.Y < 0.02)
                            r = 0;
                        else if (aTopLeft.Y - bBotRight.Y < 0.02)
                            r = 0;
                        else{
                            lPlayer.HitLeft();
                            r = 3;                        
                        }

                    }
                }
                if (b.X > a.X)		//This block is to the right of us. (Player hasa lesser X-Value)
                {
                    if ((aBotRight.Y < bTopLeft.Y && bTopLeft.Y < aTopLeft.Y) ||
                       (aBotRight.Y < bBotRight.Y && bBotRight.Y < aTopLeft.Y) ||
                       (aBotRight.Y < b.Y && b.Y < aTopLeft.Y))
                    {
                        if (bTopLeft.Y - aBotRight.Y < 0.02)
                            r = 0;
                        else if (aTopLeft.Y - bBotRight.Y < 0.02)
                            r = 0;
                        else
                        {
                            lPlayer.HitRight();
                            r = 4;
                        }
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


    }
}
