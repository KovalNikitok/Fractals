using System;
using System.Windows.Forms;
namespace Fractals
{
    public partial class FractalForm : Form
    {
        public FractalForm()
        {
            InitializeComponent();
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            FractalsMath fractalsMath = new FractalsMath();
            // Draw Levy then structure by Tree fractals
            fractalsMath.FractalLevy(drawPanel.Width, drawPanel.Height, 0.3f, e, 8);
            e.Graphics.Clear(System.Drawing.Color.White);
            fractalsMath.FractalTree(drawPanel.Width, drawPanel.Height, 25, 68, e);
        }
        private void FractalForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape: //exit
                    {
                        Close();
                        break;
                    }
                default: //Workpiece
                    {
                        break;
                    }
            }
        }
        private void FractalForm_Load(object sender, EventArgs e)
        {
        }
    }
}
