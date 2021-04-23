using System;
using System.Collections.Generic;
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

namespace SQLiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> list;
        public MainWindow()
        {
            InitializeComponent();
            Database.InitializeDatabase();
            Database.AddData("ภูมิพัฒน์ โพธิแพทย์");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            list = Database.GetData();

            foreach (String data in list)
            {
                MessageBox.Show(data);
            }

        }
    }
}
