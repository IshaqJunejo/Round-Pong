using System.Numerics;
using Raylib_cs;

namespace RoundPong
{
    // The Class for the Ball
    public class Ball
    {
        private float incidenceAngle;
        private float normalRayAngle;
        private float differenceInAngle;
        private float newAngle;
        public int score = 0;
        public float radius;
        public Vector2 pos;
        public Vector2 vel;
        public float speedOffset;

        // Method to Update the Ball's Position and Collision with Slider
        public void Update(float dt, Slider player, Sound collide)
        {
            // Changing Position using Velocity
            pos += vel * dt;

            // Variables to help with Collision
            incidenceAngle = (float) Math.Atan2(vel.Y, vel.X);
            normalRayAngle = player.angle + ChangeFrom.DegToRad(180.0f);
            differenceInAngle = normalRayAngle - incidenceAngle;

            newAngle = normalRayAngle - differenceInAngle * -2.0f;

            // Looking for Collision Activity
            for (float i = 0; i < player.length * 2; i +=  5.0f)
            {
                Vector2 ballCollide = new Vector2{};
                ballCollide.X = player.point1.X - (float)Math.Cos(player.angle + ChangeFrom.DegToRad(90.0f)) * i;
                ballCollide.Y = player.point1.Y - (float)Math.Sin(player.angle + ChangeFrom.DegToRad(90.0f)) * i;

                if (Raylib.CheckCollisionCircles(ballCollide, player.thickness / 2, pos + vel, radius))
                {
                    // Change Ball's Direction if it Collides
                    vel.X = (float) Math.Cos(newAngle) * speedOffset;
                    vel.Y = (float) Math.Sin(newAngle) * speedOffset;

                    // Increasing Score
                    score++;
                    // Playing Sound Effect
                    Raylib.PlaySound(collide);
                    // Decreasing Slider's Length, as a Challenge
                    if (player.length > 10.0f)
                    {
                        player.length -= 2.0f;
                    };
                }
            }
        }
        // Method to Draw the Ball
        public void DrawBall()
        {
            //Raylib.DrawCircleV(pos, radius * 1.50f, Color.GRAY);
            //Raylib.DrawCircleV(pos, radius * 1.25f, Color.LIGHTGRAY);
            Raylib.DrawCircleV(pos, radius * 1.00f, Color.RAYWHITE);
        }
    }
}