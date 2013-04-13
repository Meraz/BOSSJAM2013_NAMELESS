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

        public int CheckCollision(Player lPlayer, GameObject lOtherObject, float dt)
        {
           // int endRes = 0;

           // int result = 
           //// Rectangle lPlayerRectangle = lPlayer.GetRect();
           // Rectangle lOtherObjectRectangle = lOtherObject.GetRect();

           // if (lPlayerRectangle.Intersects(lOtherObjectRectangle))
           // {
           //  //
           // }


            return 1;
        }

        private int AABBCollision(Player lPlayer, GameObject lOtherObject, float dt)
        {
            //Vector2 a = lPlayer;

            return 1;
        }


    }
}
