﻿using System;
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
        public void FractalTree(int xA, int yA, int length, float angle, PaintEventArgs e)
        {

            int colorR = length * 4 % 255;
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
        public void DrawFractal(Pen pen, float xA, float yA, float xB, float yB, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.DrawLine(pen, xA, yA, xB, yB);
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            FractalTree(drawPanel.Width / 2, 0, 250, 0, e);
        }
        private void FractalForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'q':
                    {
                        TopMost = false;
                        break;
                    }
                case 'e':
                    {
                        FormBorderStyle = FormBorderStyle.SizableToolWindow;
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
