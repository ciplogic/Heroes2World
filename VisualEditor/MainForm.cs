using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using NHeroes2.Agg;
using NHeroes2.Agg.Icns;

namespace VisualEditor
{
    public partial class MainForm : Form
    {
        private Bitmap _bitmap;
        AggFile aggFile = new AggFile();

        public MainForm()
        {
            InitializeComponent();
            _bitmap = new Bitmap(128, 128, PixelFormat.Format32bppArgb);

            aggFile.Open("../data/heroes2.agg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mouse = aggFile.RenderICNSprite((int) IcnKind.HEROES, 0);
            var graphics = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            graphics.DrawLine(pen, 0, 0, 100, 100);
            
            graphics.DrawImage(mouse.first, new Point());
        }
    }
}