using System.Windows.Media;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OurChat
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ChatItemDisplay> Chats { get; } = new();
        public ObservableCollection<ChatMessage> Messages { get; } = new();

        private string _draftMessage = "";
        public string DraftMessage
        {
            get => _draftMessage;
            set { _draftMessage = value; OnPropertyChanged(); }
        }

        public MainViewModel()
{
    Chats.Add(new ChatItemDisplay { DisplayName = "alexdev", Initials = "A", LastMessagePreview = "gm dude" });
    Chats.Add(new ChatItemDisplay { DisplayName = "Dev Group", Initials = "DG", LastMessagePreview = "deploying now" });

    Messages.Add(new ChatMessage 
    { 
        Text = "gm dude what's the plan today?", 
        Time = "01:39", 
        UserName = "alexdev",
        UserNameColor = new SolidColorBrush(Color.FromRgb(67, 181, 129)),
        IsMine = false 
    });
    
    Messages.Add(new ChatMessage 
    { 
        Text = "Working on the chat UI, Discord style", 
        Time = "01:40", 
        UserName = "you", 
        UserNameColor = new SolidColorBrush(Color.FromRgb(88, 101, 242)),
        IsMine = true 
    });
}

public void Send()
{
    var text = (DraftMessage ?? "").Trim();
    if (text.Length == 0) return;

    Messages.Add(new ChatMessage
    {
        Text = text,
        Time = DateTime.Now.ToString("HH:mm"),
        UserName = "you",
        UserNameColor = new SolidColorBrush(Color.FromRgb(88, 101, 242)),
        IsMine = true
    });

    DraftMessage = "";
}


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
