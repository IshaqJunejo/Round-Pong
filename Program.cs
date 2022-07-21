using System.Numerics;
using Raylib_cs;

namespace RoundPong
{
    public class Program
    {
        public static void Main()
        {
            // Window Resolution
            const int Width = 1380;
            const int Height = 900;
            
            // Making a Window
            Raylib.InitWindow(Width, Height, "Round Pong");
            Raylib.InitAudioDevice();
            Raylib.SetMasterVolume(0.15f);

            // Instatiating the Circle or Play Area
            var playArea = new Table();
            playArea.radius = 400.0f;

            // Instatiating the Slider
            var player = new Slider();
            player.angle = ChangeFrom.DegToRad(-90.0f);
            player.length = 75.0f;
            player.defaultLength = player.length;
            player.thickness = 20.0f;

            // Instatiating the Ball
            var ball = new Ball();
            ball.speedOffset = 2.5f;
            ball.radius = 10.0f;
            ball.pos = new Vector2(Width / 2, Height / 2);
            float newAngle = Raylib.GetRandomValue(0, 360);
            ball.vel.X = (float) Math.Cos(ChangeFrom.DegToRad(newAngle)) * ball.speedOffset;
            ball.vel.Y = (float) Math.Sin(ChangeFrom.DegToRad(newAngle)) * ball.speedOffset;

            // Sound Effect(s)
            Sound collide = Raylib.LoadSound("assets/collide.wav");

            // Extra Variables
            float deltaTime;
            int targetFPS = 120;
            string scoreText;
            int fontSize = 40;
            int scoreFontSize = 80;

            // Limitating the Frames Per Second
            Raylib.SetTargetFPS(targetFPS);

            // Main Loop
            while (!Raylib.WindowShouldClose())
            {
                // updating the DeltaTime
                deltaTime = Raylib.GetFrameTime() * targetFPS;
                // Updating the Circle or Play Area
                playArea.Update(ball, deltaTime);
                // Updating Score
                scoreText = Convert.ToString(ball.score);

                // Updating the Game
                if (playArea.keepPlaying)
                {
                    player.Update(Width / 2, Height / 2, deltaTime);
                    ball.Update(deltaTime, player, collide);
                }

                // Restarting the Game after Losing
                if (!playArea.keepPlaying && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    // Resetting the Slider
                    player.angle = ChangeFrom.DegToRad(-90.0f);
                    player.length = player.defaultLength;

                    // Resetting the Circle or Play Area
                    playArea.keepPlaying = true;

                    // Resetting the Ball
                    ball.score = 0;
                    ball.pos = new Vector2(Width / 2.0f, Height / 2.0f);
                    float temp = Raylib.GetRandomValue(0, 360);
                    ball.vel.X = (float) Math.Cos(ChangeFrom.DegToRad(temp)) * ball.speedOffset;
                    ball.vel.Y = (float) Math.Cos(ChangeFrom.DegToRad(temp)) * ball.speedOffset;
                }
                
                // Drawing Session
                Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.DARKGRAY);
                    playArea.DrawTable(Width, Height);
                    
                    if (playArea.keepPlaying)
                    {
                        // Drawing the Slider and the Ball when Game is Active
                        player.DrawSlider();
                        ball.DrawBall();
                        Raylib.DrawText(scoreText, Width / 2 - Raylib.MeasureText(scoreText, (int)(scoreFontSize * 1.00f)) / 2, Height / 2 - 20, (int)(scoreFontSize * 1.00f), Color.RAYWHITE);
                    }else
                    {
                        // Asking to Restart the Game using Space Key
                        Raylib.DrawText("Press Space to Restart", Width/2 - Raylib.MeasureText("Press Space to Restart", (int)(fontSize * 1.00f)) / 2, Height/2 - 100, (int)(fontSize * 1.00f), Color.RAYWHITE);
                        Raylib.DrawText(scoreText, Width / 2 - Raylib.MeasureText(scoreText, (int)(scoreFontSize * 1.00f)) / 2, Height / 2 - 20, (int)(scoreFontSize * 1.00f), Color.RAYWHITE);
                    }
                Raylib.EndDrawing();
            }
            // End the Game
            Raylib.CloseWindow();
        }
    }
}