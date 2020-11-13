using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button btnOk = new Button();
            btnOk.Content = "확인";
            btnOk.HorizontalAlignment = HorizontalAlignment.Center;
            btnOk.VerticalAlignment = VerticalAlignment.Center;

            Debug.WriteLine("=======>:" + btnOk.Name);

            btnOk.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            this.Content = btnOk;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button is clicked\nTest message for commit");
        }
    }
}
