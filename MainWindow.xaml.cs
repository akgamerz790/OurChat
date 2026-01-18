using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OurChat
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.DashboardPage());
        }
        private void Send_Click(object sender, RoutedEventArgs e) => _vm.Send();
        private void NavigateToDashboard(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.DashboardPage());
        private void NavigateToServers(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.ServersPage());
        private void NavigateToControls(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.ControlsPage());
        private void NavigateToLogs(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.LogsPage());
        private void NavigateToSettings(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SettingsPage());
        }
    }
}