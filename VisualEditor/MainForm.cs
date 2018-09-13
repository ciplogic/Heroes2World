using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using NHeroes2.Agg;
using NHeroes2.Agg.Icns;

namespace VisualEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            graphics.DrawLine(pen, 0, 0, 100, 100);
            
        }
    }
}