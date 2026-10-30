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

namespace TV_Шаповалова
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();
        public MainWindow()
        {
            InitializeComponent();
            VideoPLayer.Source = new Uri(TV.Channels[TV.ActiveChannel].Src);
            VideoPLayer.Play();
        }

        private void BackChannel(object sender, RoutedEventArgs e)
        {
            TV.BackChannel(VideoPLayer, NameChannel);
        }

        private void NextChannel(object sender, RoutedEventArgs e)
        {
            TV.NextChannel(VideoPLayer, NameChannel);
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(numChannel.Text);
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            TV.Power(VideoPLayer, NameChannel, PowerButton);
        }

        private void DownSound_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpSound_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
