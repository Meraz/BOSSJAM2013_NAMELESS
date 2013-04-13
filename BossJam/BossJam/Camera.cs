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
    class Camera
    {
        private Vector2 Origin { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        private Rectangle Limit { get; set; }
        private Viewport viewPort;
        private float speed = 10;

        public Vector2 Position;


        public Camera(Viewport viewPort, Rectangle limit)
        {
            this.viewPort = viewPort;
            this.Limit = limit;
            Origin = Vector2.Zero;
            Zoom = 1f;
            Rotation = 0f;
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0f))
                //* Matrix.CreateTranslation(new Vector3(Origin, 0f))                       //Testa att avkommentera denna raden och kommentera den sista. Då ser ni att rotationen blir annorlunda
                 * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1f))
                 * Matrix.CreateRotationZ(Rotation)
                 * Matrix.CreateTranslation(new Vector3(Origin, 0f));
        }

        public virtual void Update(GameTime timeTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                if (!(Position.X + viewPort.Width + speed > Limit.Width))
                    Position.X += speed;
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                if (!(Position.X -speed < 0))
                    Position.X -= speed;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                if (!(Position.Y - speed < 0))
                    Position.Y -= speed;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                if (!(Position.Y + viewPort.Height + speed > Limit.Height))
                    Position.Y += speed;
            }
            Position = new Vector2(
                Player.GetPlayer().GetPos().X - 512.0f, // Hårdkodning för hårdkodningens skull
                Player.GetPlayer().GetPos().Y - 384.0f);


            Matrix.CreateTranslation(Position.X, Position.Y, 0f);
        }
    }
}
