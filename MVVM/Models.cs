using System;
using System.Windows.Media; // ← needed for SolidColorBrush and Color

namespace OurChat
{
    public class ChatMessage
    {
        public string Text { get; set; } = "";
        public string Time { get; set; } = "";
        public string UserName { get; set; } = "";
        public SolidColorBrush UserNameColor { get; set; } = new SolidColorBrush(Color.FromRgb(67, 181, 129));
        public bool IsMine { get; set; }
    }

    public class ChatItemDisplay
    {
        public string DisplayName { get; set; } = "";
        public string Initials { get; set; } = "";
        public string LastMessagePreview { get; set; } = "";
    }
}
