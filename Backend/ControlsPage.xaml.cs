using System.Windows;
using System.Windows.Controls;

namespace OurChat.Pages
{
    public partial class ControlsPage : Page
    {
        public ControlsPage()
        {
            InitializeComponent();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Sending to {txtChannelId.Text}:\n{txtMessage.Text}");
        }

        private void ClearMessage(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
        }

        private void BroadcastAll(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Broadcasting to all channels!");
        }
    }
}
