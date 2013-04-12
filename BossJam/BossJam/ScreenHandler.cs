using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BossJam
{
    class ScreenHandler
    {
        public enum ScreenState
        {
            Menu,
            InGame,
            End,
            Shutdown,
            Restart
        };
               
        private AbstractScreen mScreen;
        private MenuScreen mMenuScreen;
        private GameScreen mGameScreen;
        private EndScreen mEndScreen;
        private ScreenState mCurrentScreenState;

        private bool mShutDownFlag = false;

        ContentManager mContentManager;

        public ScreenHandler()
        {
            mMenuScreen = new MenuScreen();
            mGameScreen = new GameScreen();
            mEndScreen = new EndScreen();
        }

        public void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            mContentManager = lContentManager;
            mMenuScreen.Initialize(mContentManager, lGraphicsDevice);
            mGameScreen.Initialize(mContentManager, lGraphicsDevice);
            mEndScreen.Initialize(mContentManager, lGraphicsDevice);
            mScreen = mGameScreen;
            mCurrentScreenState = ScreenState.Menu; 
        }

        public ScreenState Update(GameTime lGameTime)
        {
            mScreen.Update(lGameTime);
            if (mScreen.GetScreenState() != mCurrentScreenState)
            {
                SwapScreenState(mScreen.GetScreenState());
            }
            return mCurrentScreenState;
        }

        private void SwapScreenState(ScreenState lScreenState)
        {
            if (lScreenState == ScreenState.Menu)
                mScreen = mMenuScreen;
            else if (lScreenState == ScreenState.InGame)
                mScreen = mGameScreen;
            else if (lScreenState == ScreenState.End)
                mScreen = mEndScreen;
            //else if (lScreenState == ScreenState.Shutdown)
            //{

            //}
            else
                return;
            mCurrentScreenState = lScreenState;
        }

        public void Draw(SpriteBatch lSpriteBatch)
        {
            mScreen.Draw(lSpriteBatch);
        }
    }
}
