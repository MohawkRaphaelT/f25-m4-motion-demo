// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Vector2[] positions =
            [
                new Vector2(200, 200),
                new Vector2( 50,  50),
                new Vector2(350, 300),
                new Vector2( 75, 325),
                new Vector2(275,  40),
                new Vector2(225,  375),
            ];
        int[] radii;

        // Setup runs once before the game loop begins.
        public void Setup()
        {
            Window.SetTitle("Cool Title");
            Window.SetSize(400, 400);
            radii = new int[positions.Length];
            for (int i = 0; i < radii.Length; i++)
            {
                radii[i] = Random.Integer(10, 50);
            }
        }

        // Update runs every frame.
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            for (int i = 0; i < positions.Length; i += 1)
            {
                Vector2 position = positions[i];
                int radius = radii[i];
                float corneaR = radius;
                float irisR = radius * 0.7f;
                float pupilR = radius * 0.35f;
                DrawEyeball(position, corneaR, irisR, pupilR);
            }
        }

        void DrawEyeball(Vector2 eyePosition, float corneaR, float irisR, float pupilR)
        {
            // Get both X and Y coordinates as a vector
            Vector2 mousePosition = Input.GetMousePosition();
            // To go from A to B, we do B minus A
            Vector2 vectorFromEyeToMouse = mousePosition - eyePosition;
            // Split vector into direction and magnitude (distance)
            Vector2 direction = Vector2.Normalize(vectorFromEyeToMouse);
            float distance = vectorFromEyeToMouse.Length();
            // Calculate where iris (and pupil) need to go
            Vector2 irisPosition = eyePosition + direction * (corneaR - irisR);

            // Cornea
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.White;
            Draw.Circle(eyePosition, corneaR);
            // Iris
            Draw.FillColor = Color.Green;
            Draw.Circle(irisPosition, irisR);
            // Pupil
            Draw.FillColor = Color.Black;
            Draw.Circle(irisPosition, pupilR);
        }
    }

}
