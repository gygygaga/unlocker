using System.Text;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
namespace unlocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string directorymain = "V908cdsz09";
        string pathmain = "C:\\Users\\" + Environment.UserName + "\\" + directorymain;

        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hwnd, string lpString);
        static string chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
        static int length = 12;
        static Random rnd = new Random();
        string randomText = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        static string exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        string exeDir = System.IO.Path.GetDirectoryName(exePath);
        public MainWindow()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length <= 1)
            {
                File.Copy(exePath, System.IO.Path.Combine(exeDir, randomText + ".exe"));
                System.Diagnostics.Process.Start("cmd.exe", $"/c start {randomText}.exe {System.Diagnostics.Process.GetCurrentProcess().ProcessName}.exe");
                this.Close();
            }
            else
            {
                string exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                string exeDir = System.IO.Path.GetDirectoryName(exePath);
                File.Delete(exeDir +"\\"+args[1]);
 
                
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        void downloader_files()
        {
            System.Diagnostics.Process.Start("curl", "-o " + pathmain + "\\nhelper.rar \"https://nhelper.nedohackers.site/NHelperV4.rar\"");
            System.Diagnostics.Process.Start("curl", "-o " + pathmain + "\\unlocker.zip \"https://simpleunlocker.ds1nc.ru/release/simpleunlocker_release.zip\"");
            logger.Text = "Unlocker ...\nDownload success.";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists("C:\\Users\\" + Environment.UserName + "\\" + directorymain))
            {
      

                downloader_files();
            }
            else
            {
                Directory.CreateDirectory(pathmain);
                downloader_files();
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe","/c "+ pathmain + "\\nhelper.rar");
            System.Diagnostics.Process.Start("cmd.exe","/c " + pathmain + "\\unlocker.zip");
            logger.Text = "Unlocker...\nAll downloaded files open";

        }
    }
}