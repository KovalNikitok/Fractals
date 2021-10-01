using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractals
{
    public partial class FractalForm : Form
    {
        public FractalForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method for drawing a fractal tree structure.
        /// #FractalTree(drawPanel.Width / 2, 0, 250, 0, e); Can be used for draw fractal
        /// </summary>
        /// <param name="xA">First value of point</param>
        /// <param name="yA">Second value of point</param>
        /// <param name="length">Length of line</param>
        /// <param name="angle">Angle of rotation a line</param>
        /// <param name="e">Painter</param>
        public void FractalTree(int xA, int yA, int length, float angle, PaintEventArgs e)
        {
            int colorR = xA * 100 % 255;
            int colorG = (colorR + 128) % 255;
            int colorB = Math.Abs((colorR - 196)) % 255;
            float xB = (float)(xA + length * Math.Sin(angle * 2 * Math.PI / 360.0));
            float yB = (float)(yA + length * Math.Cos(angle * 2 * Math.PI / 360.0));
            DrawFractal(new Pen(Color.FromArgb(colorR, colorG, colorB)), xA, (drawPanel.Height - yA), xB, drawPanel.Height - yB, e);

            if (length > 5)
            {
                FractalTree((int)xB, (int)yB, (int)(length * 0.75), angle + 35, e);
                FractalTree((int)xB, (int)yB, (int)(length * 0.75), angle - 35, e);
            }
        }
        /// <summary>
        /// Method for drawing a levy fractal structure.
        /// 
        /// </summary>
        /// <param name="xA">First value of first point</param>
        /// <param name="yA">Second value of first point</param>
        /// <param name="xB">First value of second point</param>
        /// <param name="yB">Second value of second point</param>
        /// <param name="n">Approximation of fractal</param>
        /// <param name="e">Painter</param>
        public void FractalLevy(float xA, float yA, float xB, float yB, int n, PaintEventArgs e)
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
                FractalLevy(xA, yA, xC, yC, n - 1, e);
                FractalLevy(xC, yC, xB, yB, n - 1, e);
            }
        }
        /// <summary>
        /// Method for rendering
        /// </summary>
        public void DrawFractal(Pen pen, float xA, float yA, float xB, float yB, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.DrawLine(pen, xA, yA, xB, yB);
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            
            int approxim = 11;
            float leftOffset = 0.1f,
                rightOffset;

            if (leftOffset < 0.25f)
                leftOffset = 0.25f;
            rightOffset = 1 - leftOffset;
            for (int i = 0; i < 20; i++)
            {
                if (leftOffset > 0.5f)
                    break;
                FractalLevy(drawPanel.Width / 2f, drawPanel.Height * rightOffset, drawPanel.Width / 2f, drawPanel.Height * leftOffset, approxim, e);
                FractalLevy(drawPanel.Width / 2f, drawPanel.Height * leftOffset, drawPanel.Width / 2f, drawPanel.Height * rightOffset, approxim, e);
                leftOffset += 0.02f;
                rightOffset -= 0.02f;
            }
        }
        private void FractalForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'q':
                    {
                        break;
                    }
                default:
                    {
                        Close();
                        break;
                    }
            }
        }
        private void FractalForm_Load(object sender, EventArgs e)
        {
        }
    }
}
