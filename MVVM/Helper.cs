using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace OurChat.Helpers // Adjust namespace to match your project
{
    public static class SmoothScrollViewerHelper
    {
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.RegisterAttached("VerticalOffset", typeof(double), typeof(SmoothScrollViewerHelper),
                new PropertyMetadata(0.0, OnVerticalOffsetChanged));

        public static void SetVerticalOffset(DependencyObject target, double value) => target.SetValue(VerticalOffsetProperty, value);
        public static double GetVerticalOffset(DependencyObject target) => (double)target.GetValue(VerticalOffsetProperty);

        private static void OnVerticalOffsetChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target is ScrollViewer scrollViewer)
            {
                scrollViewer.ScrollToVerticalOffset((double)e.NewValue);
            }
        }
    }
}