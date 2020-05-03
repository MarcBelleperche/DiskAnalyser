using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace DiskAnalysers
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Disks> items = new List<Disks>();
            foreach (var drive in DriveInfo.GetDrives())
            {
                Console.WriteLine("Drive Type: {0}", drive.DriveType);
                Console.WriteLine("Drive Size: {0}", drive.TotalSize);
                Console.WriteLine("Drive Free Space: {0}", drive.TotalFreeSpace);
                Console.WriteLine("Drive name : ", drive.Name);

                FileInfo f = new FileInfo(drive.Name);
                string driven = System.IO.Path.GetPathRoot(f.FullName);
                Console.WriteLine(driven);

                double str_left = drive.AvailableFreeSpace / (1000000000.00) ;
                double str_total = drive.TotalSize / (1000000000.00);
                double str_used = ((drive.TotalSize - drive.AvailableFreeSpace) / 1000000000.00);
                //items.Add(new Disks() { name = "Marc", storage_left = 12, storage_used = 15 });
                items.Add(new Disks(){ name = driven, storage_left = Math.Round(str_left, 2), storage_tot = Math.Round(str_total, 2), storage_used = Math.Round(str_used, 2) });

                //disklist.Items.Add();
            }
            //items.Add(new Disks() {name = "Marc", storage_left = 12, storage_used = 15 });
            lDisks.ItemsSource = items;
        }

        private void lDisks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Disks seldisk = (Disks)lDisks.SelectedItem;
            Console.WriteLine("The selected disk is : " + seldisk.name);
        }

        private void Gitbut_click(Object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MarcBelleperche?tab=repositories");
        }

        private void lDisks_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void lDisks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Disks seldisk = (Disks)lDisks.SelectedItem;
            Console.WriteLine("Opening the " + seldisk.name + " disk.");
            this.Hide();
            DiskAnals gladal = new DiskAnals(seldisk);
            gladal.Show();
        }
    }
}
