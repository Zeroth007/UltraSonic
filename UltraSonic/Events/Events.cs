﻿using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using CheckBox = System.Windows.Controls.CheckBox;

namespace UltraSonic
{
    public partial class MainWindow
    {
        private void MediaPlayerMediaOpened(object sender, RoutedEventArgs e)
        {
            if (!MediaPlayer.NaturalDuration.HasTimeSpan) return;

            Dispatcher.Invoke(() =>
                                  {
                                      _position = MediaPlayer.NaturalDuration.TimeSpan;
                                      ProgressSlider.Minimum = 0;
                                      ProgressSlider.Maximum = _position.TotalMilliseconds;
                                  });
        }

        void DataGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString(CultureInfo.InvariantCulture);
        }

        private void StarredCheckBoxClick(object sender, RoutedEventArgs e)
        {
            ChangeItemStarState(e.Source as CheckBox);
        }
    }
}