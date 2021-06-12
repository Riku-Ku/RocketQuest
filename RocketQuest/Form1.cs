using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketQuest
{
    public partial class MainWindow : Form
    {
        HitBox hitbox = new HitBox();
        public MainWindow()
        {
            InitializeComponent();
            //timer.Enabled = true;
            //timer.Interval = 100;  /* 100 millisec */
            //timer.Tick += new EventHandler(TimerCallback);
        }
        
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Point exitBTNLocation = new Point(this.Width - exitBtn.Width, 0);
            exitBtn.Location = exitBTNLocation;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            RocketAppClosing();
        }

        private void RocketAppClosing()
        {
            this.Close();
        } 

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A)
            {
                hitbox.SetPoint = new Point(hitbox.SetPoint.X, hitbox.SetPoint.Y - 50);

            }
        }
        Timer timer = new Timer();

        private void TimerCallback(object sender, EventArgs e)
        {
            this.Invalidate();
            return;
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            //hitbox.SetWidth = 400;
            //hitbox.SetHeight = 300;
            //hitbox.SetPoint = new Point(20, 30);
            //g.FillRectangle(Brushes.Blue, hitbox.SetPoint.X, hitbox.SetPoint.Y, hitbox.SetWidth, hitbox.SetHeight);

        }
        
        //Reject humanity, return to monkey
        //hi
        //rocket
        //commentnew
    }
}
