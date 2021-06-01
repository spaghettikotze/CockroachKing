using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CockroachKing
{
    static class Helper
    {
        public static Player SpawnPlayer(Texture2D sprite, Vector2 position, float maxSpeed, Vector2 scale)
        {
            Player player = new Player(sprite, position, maxSpeed, scale);
            //player.Collider.Add(new CircleCollider(player, new Vector2(0.02558854167f, 0.04317592593f), scale, 30));
            return player;
        }

        /*public static bool Collided(GameObject a, GameObject b)
        {
            bool collision = false;

            int i = 0;
            int j = 0;
            float dist2 = 0;
            float r2 = 0;
            while (i < a.Collider.Count)
            {
                while (j < b.Collider.Count)
                {
                    dist2 = Vector2.DistanceSquared(a.Collider[i].Position, b.Collider[j].Position);
                    r2 = (a.Collider[i].Radius + b.Collider[j].Radius) * (a.Collider[i].Radius + b.Collider[j].Radius);
                    if (dist2 < r2)
                    {
                        collision = true;
                        break;
                    }
                    j++;
                }
                if (collision)
                    break;
                i++;
            }

            return collision;
        }*/

        /*public static void CollisionHandler(List<GameObject> objects, GameTime gameTime)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                GameObject currentObject = objects[i];
                double deltaTime = gameTime.TotalGameTime.TotalSeconds - currentObject.LastCollisionTime;
                for (int j = 0; j < objects.Count; j++)
                {
                    GameObject otherObject = objects[j];
                    if (currentObject == otherObject || (deltaTime < 2 && otherObject == currentObject.LastCollisionObject))
                        continue;
                    if (Collided(currentObject, otherObject))
                    {

                        if (currentObject is Projectile)
                        {
                            Projectile currentProjectile = (Projectile)currentObject;
                            if (otherObject == currentProjectile.Owner || otherObject is Projectile)
                                continue;
                            otherObject.Hit(currentProjectile.Power);
                            currentProjectile.Impact = true;
                        }
                        else if (!(otherObject is Projectile))
                        {
                            otherObject.Hit(otherObject.Hitpoints / 2);
                            currentObject.Hit(currentObject.Hitpoints / 2);
                        }

                        otherObject.LastCollisionObject = currentObject;
                        currentObject.LastCollisionObject = otherObject;

                    }

                }
            }
        }*/

        public static void PlayerHandler(Player player, MouseListener mouse, KeyboardListener keyboard)
        {
            float xAcc = 10f;
            float yAcc = 10f;
            player.Velocity = new Vector2();
            player.Acceleration = new Vector2();

            if (keyboard.KeyPressed(Keys.Left) || keyboard.KeyPressed(Keys.A))
                player.Acceleration = new Vector2(-xAcc, player.Acceleration.Y);
            if (keyboard.KeyPressed(Keys.Right) || keyboard.KeyPressed(Keys.D))
                player.Acceleration = new Vector2(xAcc, player.Acceleration.Y);

            /*if (keyboard.KeyPressed(Keys.Down) || keyboard.KeyPressed(Keys.S))
                player.Acceleration = new Vector2(player.Acceleration.X, yAcc);*/
            /*if (keyboard.KeyPressed(Keys.Up) || keyboard.KeyPressed(Keys.W))
                player.Acceleration = new Vector2(player.Acceleration.X, -yAcc);*/       
        }

    }
}
