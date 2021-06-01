using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CockroachKing
{
    class GameObject
    {
        public Texture2D Sprite { get; set; }
        //public GameObject LastCollisionObject { get; set; }
        //public List<CircleCollider> Collider { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 Scale { get; set; }
        public float MaxSpeed { get; set; }
        public float Rotation { get; set; }
        //public float Mass { get; set; }
        //public double LastCollisionTime { get; set; }

        protected GameObject()
        {
            //this.LastCollisionTime = -1;
            //this.LastCollisionObject = null;
            //this.Collider = new List<CircleCollider>();
        }
        public GameObject(Texture2D sprite, Vector2 position, float maxSpeed,
         Vector2 scale)
        {
            this.Sprite = sprite;
            this.Position = position;
            this.Velocity = new Vector2();
            this.MaxSpeed = maxSpeed;
            this.Scale = scale;
            this.Rotation = 0;
            //this.LastCollisionTime = -1;
            //this.LastCollisionObject = null;
            //this.Collider = new List<CircleCollider>();
        }
        protected void checkSpeed()
        {
            float speed = Velocity.Length();
            if (speed > MaxSpeed)
            {
                Velocity.Normalize();
                Velocity *= MaxSpeed;
            }
        }

    }
}
