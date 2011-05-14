using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Phone.Controls;

namespace LaundryTime
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            washerTimer = new DispatcherTimer();
            washerTimer.Tick += WasherTimerTick;
            dryerTimer = new DispatcherTimer();
            dryerTimer.Tick += DryerTimerTick;
        }

        private const int WasherRunTime = 2;
        private const int DryerRunTime = 2;

        private DateTime washerStartTime;
        private DateTime dryerStartTime;

        private DispatcherTimer washerTimer;
        private DispatcherTimer dryerTimer;

        private void WasherTimerTick(object sender, EventArgs e)
        {
            if (washerStartTime == null)
                throw new Exception("Washer Start Time can not be null!");
            var elapsedTime = DateTime.Now.Subtract(washerStartTime);
            var remainingTime = WasherRunTime - elapsedTime.TotalMinutes;
            var displayTime = Math.Ceiling(remainingTime);
            WasherCountdownText.Text = displayTime.ToString();
            WasherCountdownText.UpdateLayout();
            if (remainingTime <= 0)
            {
                washerTimer.Stop();
                MessageBox.Show("Washer's Done!");
            }
        }

        private void DryerTimerTick(object sender, EventArgs e)
        {
            if (dryerStartTime == null)
                throw new Exception("Dryer Start Time can not be null!");
            var elapsedTime = DateTime.Now.Subtract(dryerStartTime);
            var remainingTime = WasherRunTime - elapsedTime.TotalMinutes;
            var displayTime = Math.Ceiling(remainingTime);
            DryerCountdownText.Text = displayTime.ToString();
            DryerCountdownText.UpdateLayout();
            if (remainingTime <= 0)
            {
                dryerTimer.Stop();
                MessageBox.Show("Dryer's Done!");
            }
        }

        private void WasherButton_Click(object sender, RoutedEventArgs e)
        {
            washerStartTime = DateTime.Now;
            washerTimer.Start();
        }

        private void DryerButton_Click(object sender, RoutedEventArgs e)
        {
            dryerStartTime = DateTime.Now;
            dryerTimer.Start();
        }

        private void SettingsIconButton_Click(object sender, EventArgs e)
        {
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}