//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//namespace RocketQuest.MenuItems
//{
//    class PanelMenuMain
//    {
//        Panel menuBack = new Panel();


//        public Panel MenuDrawer(MainWindow form)
//        {
//            Size menuSize = new Size(form.Width, form.Height);
//            menuBack.Size = menuSize;
//            menuBack.BackgroundImage = RocketQuest.Properties.Resources.menuBackGr;
//            menuBack.BackgroundImageLayout = ImageLayout.Stretch;
//            menuBack.BringToFront();

//            menuBack.Controls.Add(GetStartBTN(menuBack));

//            menuBack.Show();
//            return menuBack;
//        }

        
//        Button startBTN = new Button();
//        private Button GetStartBTN(Panel panelMenuBack)
//        {
//            startBTN.Size = new Size((int)(panelMenuBack.Width * 0.2), 60);
//            startBTN.Location = new Point((int)(panelMenuBack.Width * 0.5) - (int)(startBTN.Width*0.5), (int)(panelMenuBack.Height * 0.3));
//            startBTN.Text = "Играть";
//            startBTN.FlatStyle = FlatStyle.Flat;
//            startBTN.BackColor = Color.BlueViolet;
//            return startBTN;
//        }
//    }
//}
