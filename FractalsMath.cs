using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractals
{
    class FractalsMath
    {
        /// <summary>
        /// Method for calculate a fractal tree structure.
        /// </summary>
        /// <param name="xA">First value of point</param>
        /// <param name="yA">Second value of point</param>
        /// <param name="length">Length of line</param>
        /// <param name="angle">Angle of rotation a line</param>
        /// <param name="e">Painter</param>
        public void ConstructFractalTree(int xA, int yA, int length, float angle, PaintEventArgs e)
        {
            int colorR = xA * 100 % 255;
            int colorG = (colorR + 128) % 255;
            int colorB = Math.Abs((colorR - 196)) % 255;
            float xB = (float)(xA + length * Math.Sin(angle * 2 * Math.PI / 360.0));
            float yB = (float)(yA + length * Math.Cos(angle * 2 * Math.PI / 360.0));

            DrawFractal(new Pen(Color.FromArgb(colorR, colorG, colorB)), xA, yA, xB, yB, e);
            if (length > 5)
            {
                ConstructFractalTree((int)xB, (int)yB, (int)(length * 0.75), angle + 40, e);
                ConstructFractalTree((int)xB, (int)yB, (int)(length * 0.75), angle - 40, e);
            }
        }
        /// <summary>
        /// Method for drawing a fractal tree structure.
        /// </summary>
        /// <param name="screenWidth">Width of the screen</param>
        /// <param name="screenHeight">Heigth of the screen</param>
        /// <param name="offset">Offset of each fractal structure</param>
        /// <param name="angle">Angle of rotation an each fractal structure</param>
        /// <param name="e">Painter</param>
        public void FractalTree(int screenWidth, int screenHeight, int offset, int angle, PaintEventArgs e)
        {
            int width = screenWidth / 2,
                    height = screenHeight / 2;
            int baseAngle = -90 + angle,
                    length = 150;
            while (length > 5)
            {
                for (int i = 0; i < 4; i++)
                {
                    baseAngle %= 360;
                    ConstructFractalTree(width, height, length, baseAngle, e);
                    baseAngle += 90;
                }
                length -= offset;
                baseAngle -= 10;
            }
        }
        /// <summary>
        /// Method for calculate a levy fractal structure.
        /// </summary>
        /// <param name="xA">First value of first point</param>
        /// <param name="yA">Second value of first point</param>
        /// <param name="xB">First value of second point</param>
        /// <param name="yB">Second value of second point</param>
        /// <param name="n">Approximation of fractal</param>
        private void ConstructFractalLevy(float xA, float yA, float xB, float yB, int n, PaintEventArgs e)
        {
            if (n == 0)
            {
                int colorR = (int)xA * 100 % 255;
                int colorG = (int)yA * 75 % 255;
                int colorB = (int)xB * 50 % 255;
                DrawFractal(new Pen(Color.FromArgb(colorR, colorG, colorB)), xA, yA, xB, yB, e);
            }
            else
            {
                float xC = (xA + xB) / 2 + (yB - yA) / 2;
                float yC = (yA + yB) / 2 - (xB - xA) / 2;
                ConstructFractalLevy(xA, yA, xC, yC, n - 1, e);
                ConstructFractalLevy(xC, yC, xB, yB, n - 1, e);
            }
        }
        /// <summary>
        /// Method for drawing a fractal levy structure.
        /// </summary>
        /// <param name="screenWidth">Width of the screen</param>
        /// <param name="screenHeight">Heigth of the screen</param>
        /// <param name="offset">Offset of each fractal structure</param>
        /// <param name="e">Painter</param>
        /// <param name="approxim">Approximation of fractal</param>
        public void FractalLevy(float screenWidth, float screenHeight, float offset, PaintEventArgs e, int approxim = 5)
        {
            float width = screenWidth / 2.0f;
            if (offset < 0.25f)
                offset = 0.25f;
            float rightOffset = 1 - offset;
            for (int i = 0; i < 20; i++)
            {
                if (offset > 0.5f)
                    break;
                ConstructFractalLevy(width, screenHeight * rightOffset, width, screenHeight * offset, approxim, e);
                ConstructFractalLevy(width, screenHeight * offset, width, screenHeight * rightOffset, approxim, e);
                offset += 0.02f;
                rightOffset -= 0.02f;
            }
        }
        /// <summary>
        /// Method for rendering
        /// </summary>   
        private void DrawFractal(Pen pen, float xA, float yA, float xB, float yB, PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, xA, yA, xB, yB);
        }
    }
}