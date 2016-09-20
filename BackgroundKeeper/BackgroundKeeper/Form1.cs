using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace BackgroundKeeper {
    public partial class Form1 : Form {

        private BackgroundControl background = new BackgroundControl(@"C:\Users\Intern\Pictures\WallPaper\StarWars.jpg");
        private bool onlyDoOnce = false;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Hide();
            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon(@"D:\GitHub\DontChangeMyBackground\BackgroundKeeper\BackgroundKeeper\Icons\AssetStoreFiddler_icon.ico");
            trayIcon.Visible = true;
        }

        protected override void WndProc(ref Message message) {
            if (message.Msg == background.CheckChange()) {
                if (message.WParam.ToInt32() == background.CheckSetWallPaper()) {
                    background.SetWallpaper(background.getPath());
                    //Process.Start("http://www.google.com/");
                }
            }
            base.WndProc(ref message);
        }
    }
}
