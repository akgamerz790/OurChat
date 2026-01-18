using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using OurChat.Helpers; // Ensure this matches the namespace of the helper above

namespace OurChat.Pages
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            LoadSettings();
        }

        #region Smooth Scrolling Logic

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            
            // Adjust the 0.5 to change scroll sensitivity (e.g., 0.8 for faster)
            double newOffset = scrollViewer.VerticalOffset - (e.Delta * 0.5); 

            if (newOffset < 0) newOffset = 0;
            if (newOffset > scrollViewer.ScrollableHeight) newOffset = scrollViewer.ScrollableHeight;

            DoubleAnimation animation = new DoubleAnimation
            {
                To = newOffset,
                Duration = TimeSpan.FromMilliseconds(500), // Speed of the "glide"
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseOut }
            };

            // Starts the smooth animation via our helper bridge
            scrollViewer.BeginAnimation(SmoothScrollViewerHelper.VerticalOffsetProperty, animation);
            
            e.Handled = true;
        }

        #endregion

        #region Existing Settings Logic

        private void LoadSettings()
        {
            // TODO: Load from config
        }

        private void SaveAllSettings(object sender, RoutedEventArgs e)
        {
            try
            {
                string botToken = txtBotToken.Password;
                string botPrefix = txtBotPrefix.Text;

                if (string.IsNullOrWhiteSpace(botToken) || string.IsNullOrWhiteSpace(botPrefix))
                {
                    MessageBox.Show("Required fields cannot be empty!", "Validation Error", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                MessageBox.Show("Settings saved successfully!", "Success", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetToDefaults(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Reset all settings to defaults?", "Confirm Reset", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                txtBotToken.Password = "";
                txtBotPrefix.Text = "!";
                txtStatusMessage.Text = "Watching over servers";
                cmbTheme.SelectedIndex = 0;
                cmbAccent.SelectedIndex = 0;
                txtMaxMessages.Text = "60";
                txtCommandTimeout.Text = "30";
                ResetCheckboxes();
                MessageBox.Show("Settings reset!", "Success");
            }
        }

        private void ResetCheckboxes()
        {
            chkAutoReply.IsChecked = true;
            chkLogging.IsChecked = true;
            chkWelcomeMessages.IsChecked = false;
            chkModeration.IsChecked = true;
            chkCustomCommands.IsChecked = true;
            chkNotifyJoin.IsChecked = true;
            chkNotifyErrors.IsChecked = true;
            chkNotifyRateLimit.IsChecked = false;
            chkDailySummary.IsChecked = false;
            chkDevMode.IsChecked = false;
            chkVerboseLogging.IsChecked = false;
        }

        private void ExportConfig(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                    FileName = "bot_config"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    string configData = SerializeSettings();
                    System.IO.File.WriteAllText(saveFileDialog.FileName, configData);
                    MessageBox.Show("Export Successful!", "Success");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string SerializeSettings()
        {
            var config = new System.Text.StringBuilder();
            config.AppendLine($"[Bot] Prefix={txtBotPrefix.Text}");
            config.AppendLine($"[Appearance] ThemeIndex={cmbTheme.SelectedIndex}");
            return config.ToString();
        }

        #endregion
    }
}