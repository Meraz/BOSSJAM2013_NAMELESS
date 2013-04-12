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
    abstract class AbstractScreen
    {
        protected ScreenHandler.ScreenState mScreenState;
        protected ContentManager mContentManager;
        protected KeyboardState mCurrentKeyboardState;
        protected KeyboardState mPreviousKeyboardState;
        protected GraphicsDevice mGraphicsDevice;

        public AbstractScreen()
        {
            mScreenState = ScreenHandler.ScreenState.Menu;
        }

        public virtual void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            mContentManager = lContentManager;
            mGraphicsDevice = lGraphicsDevice;
        }
        
        public virtual void Update(GameTime lGameTime)
        {
            mPreviousKeyboardState = mCurrentKeyboardState;
            mCurrentKeyboardState = Keyboard.GetState();

            CheckKey();
        }

        protected virtual void CheckKey()
        {
            if (mCurrentKeyboardState.IsKeyDown(Keys.Q) && mPreviousKeyboardState.IsKeyUp(Keys.Q))
                mScreenState = ScreenHandler.ScreenState.Menu;
            if (mCurrentKeyboardState.IsKeyDown(Keys.W) && mPreviousKeyboardState.IsKeyUp(Keys.W))
                mScreenState = ScreenHandler.ScreenState.InGame;
            if (mCurrentKeyboardState.IsKeyDown(Keys.E) && mPreviousKeyboardState.IsKeyUp(Keys.E))
                mScreenState = ScreenHandler.ScreenState.End;
            if (mCurrentKeyboardState.IsKeyDown(Keys.O) && mPreviousKeyboardState.IsKeyUp(Keys.O))
                mScreenState = ScreenHandler.ScreenState.Shutdown;
        }
        
        public virtual void Draw(SpriteBatch lSpriteBatch)
        {

        }

        public ScreenHandler.ScreenState GetScreenState()
        {
            return mScreenState;
        }

        public void ActivateScreenState(ScreenHandler.ScreenState lScreenState)
        {
            mScreenState = lScreenState;
        }
    }
}
