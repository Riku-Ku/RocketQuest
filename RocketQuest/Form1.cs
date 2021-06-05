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
        public MainWindow()
        {
            InitializeComponent();
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
        //Reject humanity, return to monkey
        //hi
        //rocket
        //commentnew
    }
}
