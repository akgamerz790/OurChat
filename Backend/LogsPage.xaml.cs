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
public partial class LogsPage : Page
{
    public LogsPage()
    {
        InitializeComponent();
    }

    private void ClearLogs(object sender, RoutedEventArgs e)
    {
        LogContainer.Children.Clear(); // Clears all log entries
    }
}
