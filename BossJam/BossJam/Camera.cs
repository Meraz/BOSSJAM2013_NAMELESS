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
        private Rectangle? Limit { get; set; }
        private Viewport viewPort;
        private Vector2 pPosition;
        private float speed = 10;

        public Vector2 Position
        {

            get { return pPosition; }
            set
            {
                pPosition = value;
                if (Limit != null)
                {
                    pPosition.X = MathHelper.Clamp(pPosition.X, ((Rectangle)Limit).X, Origin.X + 2000 - viewPort.Width);          //((Rectangle)Limit).Width  Kollar så att kameran håller sig innan för sin max och min-gräns
                    pPosition.Y = MathHelper.Clamp(pPosition.Y, ((Rectangle)Limit).Y, Origin.Y + 2000 - viewPort.Height);         //((Rectangle)Limit).Height
                }
            }
        }

        public Camera(Viewport viewPort, Rectangle? limit)
        {
            this.viewPort = viewPort;
            this.Limit = limit;
            //Origin = new Vector2(-viewPort.Width / 2, -viewPort.Height / 2);
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
            if (ks.IsKeyDown(Keys.Add))
            {
                Zoom += 0.01f;
            }
            if (ks.IsKeyDown(Keys.Subtract))
            {
                Zoom -= 0.01f;
            }
            if (ks.IsKeyDown(Keys.Multiply))
            {
                Zoom = 1;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                Position = new Vector2(Position.X + speed, Position.Y);
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                Position = new Vector2(Position.X - speed, Position.Y);
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X, Position.Y - speed);
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X, Position.Y + speed);
            }
            Matrix.CreateTranslation(Position.X, Position.Y, 0f);
        }
    }
}
