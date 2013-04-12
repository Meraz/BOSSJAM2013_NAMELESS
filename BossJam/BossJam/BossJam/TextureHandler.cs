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
            A,
            B
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
            
            mTexture.Add(lContentManager.Load<Texture2D>("Images/Chrysanthemum"));
        }

        public Texture2D GetTexture(TextureType lTextureType)
        {
            if (lTextureType == TextureType.A)
                return mTexture.ElementAt(0);
            if (lTextureType == TextureType.B)
                return mTexture.ElementAt(0);
            return mTexture.ElementAt(0);
        }

        //Private Functions
        private TextureHandler() {}
    }
}
