using System.Numerics;
using Raylib_cs;

namespace RoundPong
{
    // The Class for The Circle or The Play Area
    public class Table
    {
        private float angularOffset = 0.0f;
        public float radius;
        public bool keepPlaying = true;

        // Method to update the Play Area
        public void Update(Ball ping, float dt)
        {
            // Rotating the Play Area
            angularOffset += 0.0005f * dt;

            if (angularOffset >= 6.28319f)
            {
                angularOffset = 0.0f;
            };

            // Checking if the Ball is still inside or not
            float deltaX = (1350 / 2.0f) - ping.pos.X;
            float deltaY = (900 / 2.0f) - ping.pos.Y;

            if (deltaX * deltaX + deltaY * deltaY >= radius*radius * 1.05f * 1.05f)
            {
                keepPlaying = false;
                ping.pos.X = 1350 / 2.0f;
                ping.pos.Y = 900 / 2.0f;
            };
        }
        
        // Method to Draw the Play Area
        public void DrawTable(int w, int h)
        {
            // Drawing the Main Dotted Circle
            for (float rad = 0.0f; rad < 6.28319f; rad += 0.04f)
            {
                float posX = (w / 2) + ((float)Math.Cos(rad + angularOffset) * radius);
                float posY = (h / 2) + ((float)Math.Sin(rad + angularOffset) * radius);

                Raylib.DrawCircleV(new Vector2(posX, posY), 2.5f * 1.00f, Color.RAYWHITE);
            }
        }
    }
}