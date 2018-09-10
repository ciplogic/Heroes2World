using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace VisualEditor
{
    public partial class MainForm : Form
    {
        private Bitmap _bitmap;
        public MainForm()
        {
            InitializeComponent();
            _bitmap = new Bitmap(128, 128, PixelFormat.Format32bppArgb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            graphics.DrawLine(pen, 0,0, 100,100);
        }
    }
}
