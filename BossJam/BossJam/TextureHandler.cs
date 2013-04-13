using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BossJam
{
    sealed class TextureHandler //Sealed means it cannot be inherited.
    {
        public enum TextureType //Must be public to allow outside use
        {
            PLAYER = 1,
            LAMP,
            AIRPORT,
            BEARTRAP,
            NEURON,
            BLOCK,
            UI
        };

        //Variables
        static private TextureHandler mTextureHandler = new TextureHandler();
        List<Texture2D> mTexture;

        //Public Functions
        public static TextureHandler GetTextureHandler()
        {
            return mTextureHandler;
        }
        
        public void Initialize(ContentManager lContentManager)
        {
            mTexture = new List<Texture2D>();

            mTexture.Add(lContentManager.Load<Texture2D>("Images/Error")); // 0        
            mTexture.Add(lContentManager.Load<Texture2D>("Images/Player_PH")); // 1 - PLAYER
			mTexture.Add(lContentManager.Load<Texture2D>("Images/Lamp")); // 2 - LAMP
            mTexture.Add(lContentManager.Load<Texture2D>("Images/Airport_PH")); // 3 - Airportsecurity
            mTexture.Add(lContentManager.Load<Texture2D>("Images/Beartrap_PH")); // 4 - Beartrapbrain
            mTexture.Add(lContentManager.Load<Texture2D>("Images/Neuron_PH")); // 5 - Neuron
			mTexture.Add(lContentManager.Load<Texture2D>("Images/Block"));
            mTexture.Add(lContentManager.Load<Texture2D>("Images/UI_Overlay")); //UI-overlay
        }

        public Texture2D GetTexture(TextureType lTextureType)
        {
            for(int i = 1; i < mTexture.Capacity; i++)
            {
                if((int)lTextureType == i)
                {
                    return mTexture.ElementAt(i);
                }
            }
            return mTexture.ElementAt(0);
        }

        //Private Functions
        private TextureHandler() {}
    }
}
