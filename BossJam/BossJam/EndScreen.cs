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
    class EndScreen : AbstractScreen
    {
        public EndScreen()
        {

        }

        public override void Initialize(ContentManager lContentManager, GraphicsDevice lGraphicsDevice)
        {
            base.Initialize(lContentManager, lGraphicsDevice);
        }

        public override void Update(GameTime lGameTime)
        {
            base.Update(lGameTime);
            Console.WriteLine("EndScreen"); 
        }

        public override void Draw(SpriteBatch lSpriteBatch)
        {
            lSpriteBatch.Draw(TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.ENDSCREEN),
                new Rectangle(0, 0,
                    TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.ENDSCREEN).Width,
                    TextureHandler.GetTextureHandler().GetTexture(TextureHandler.TextureType.ENDSCREEN).Height),
                    Color.White);
        }
    }
}
