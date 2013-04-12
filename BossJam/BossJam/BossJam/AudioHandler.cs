using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;


namespace BossJam
{
    sealed class AudioHandler //Sealed means it cannot be inherited.
    {
        public enum AudioType //Must be public to allow outside use
        {
            A,
            B
        };

        //Variables
        static private AudioHandler mAudioHandler = new AudioHandler();
        List<SoundEffect> mTexture;

        //Public Functions
        public static AudioHandler GetAudioHandler()
        {
            return mAudioHandler;
        }

        public void Initialize(ContentManager lContentManager)
        {
            mTexture = new List<SoundEffect>();

        }

        public SoundEffect GetSoundEffect(AudioType lTextureType)
        {
            if (lTextureType == AudioType.A)
                return mTexture.ElementAt(0);
            if (lTextureType == AudioType.B)
                return mTexture.ElementAt(0);
            return mTexture.ElementAt(0);
        }

        //Private Functions
        private AudioHandler() { }


        /*
         
         // The aspect ratio determines how to scale 3d to 2d projection.
        float aspectRatio;

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            myModel = Content.Load<Model>("Models\\p1_wedge");
            soundEngine = Content.Load<SoundEffect>("Audio\\Waves\\engine_2");
            soundEngineInstance = soundEngine.CreateInstance();
            soundHyperspaceActivation = 
                Content.Load<SoundEffect>("Audio\\Waves\\hyperspace_activate");

            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
        }
         
         */
    }
}
