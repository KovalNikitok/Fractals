using System;
using System.Windows.Forms;
using System.Drawing;
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
            fractalsMath.FractalTree(drawPanel.Width, drawPanel.Height, 25, 68, e);
            //fractalsMath.FractalLevy(drawPanel.Width, drawPanel.Height, 0.3f, e, 8);
        }
        private void FractalForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                default:
                    {//Workpiece
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
