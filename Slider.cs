using System.Numerics;
using Raylib_cs;

namespace RoundPong
{
    // The Class for the Slider
    public class Slider
    {
        public float angle;
        public float length;
        public float defaultLength;
        public float thickness;
        public Vector2 fulcrum;
        public Vector2 point1;
        public Vector2 point2;
        
        // Method for Updating the Position, Angle and Length of the Slider
        public void Update(float offsetX, float offsetY, float dt)
        {
            // Updating Postion and alignment according to the Angle
            float posX = ((float) Math.Cos(angle) * 400.0f) + offsetX;
            float posY = ((float) Math.Sin(angle) * 400.0f) + offsetY;

            fulcrum.X = posX;
            fulcrum.Y = posY;

            float posX1 = fulcrum.X + ((float) Math.Cos(angle + ChangeFrom.DegToRad(90.0f)) * length);
            float posY1 = fulcrum.Y + ((float) Math.Sin(angle + ChangeFrom.DegToRad(90.0f)) * length);

            float posX2 = fulcrum.X - ((float) Math.Cos(angle + ChangeFrom.DegToRad(90.0f)) * length);
            float posY2 = fulcrum.Y - ((float) Math.Sin(angle + ChangeFrom.DegToRad(90.0f)) * length);

            point1.X = posX1;
            point1.Y = posY1;

            point2.X = posX2;
            point2.Y = posY2;

            // Updating the Angle using the Player Input
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                angle -= 0.03f * dt;
            }else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                angle += 0.03f * dt;
            }
        }

        // Method to Draw the Slider
        public void DrawSlider()
        {
            //Raylib.DrawCircleV(point1, thickness / 2 * 1.50f, Color.GRAY);
            //Raylib.DrawCircleV(point2, thickness / 2 * 1.50f, Color.GRAY);

            //Raylib.DrawCircleV(point1, thickness / 2 * 1.25f, Color.LIGHTGRAY);
            //Raylib.DrawCircleV(point2, thickness / 2 * 1.25f, Color.LIGHTGRAY);

            Raylib.DrawCircleV(point1, thickness / 2 * 1.00f, Color.RAYWHITE);
            Raylib.DrawCircleV(point2, thickness / 2 * 1.00f, Color.RAYWHITE);

            //Raylib.DrawLineEx(point1, point2, thickness * 1.50f, Color.GRAY);
            //Raylib.DrawLineEx(point1, point2, thickness * 1.25f, Color.LIGHTGRAY);
            Raylib.DrawLineEx(point1, point2, thickness * 1.00f, Color.RAYWHITE);
        }
    }
}