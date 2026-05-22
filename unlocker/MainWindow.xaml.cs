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
namespace unlocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string directorymain = "V908cdsz09";
        string pathmain = "C:\\Users\\" + Environment.UserName + "\\" + directorymain;
        public MainWindow()
        {
            InitializeComponent();
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