using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool CheckCollision(GameObject lPlayer, GameObject lOtherObject)
        {
            if (lPlayer.GetRect().Intersects(lOtherObject.GetRect()))
                return true;

            return false;
        }



    }
}
