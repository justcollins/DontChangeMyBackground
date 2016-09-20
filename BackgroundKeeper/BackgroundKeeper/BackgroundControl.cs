using System;
using System.Runtime.InteropServices;

namespace BackgroundKeeper {
    public class BackgroundControl {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;
        private static readonly UInt32 WM_SETTINGCHANGE = 0x1A;
        private static string path;

        public BackgroundControl(string _path) {
            path = _path;
        }

        public string getPath() {
            return path;
        }

        public UInt32 CheckChange() {
            return WM_SETTINGCHANGE;
        }

        public UInt32 CheckSetWallPaper() {
            return SPI_SETDESKWALLPAPER;
        }

        public void SetWallpaper(String path) {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
