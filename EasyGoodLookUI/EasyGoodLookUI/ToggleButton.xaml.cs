﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyGoodLookUI
{
    /// <summary>
    /// ToggleButton.xaml 的交互逻辑
    /// </summary>
    public partial class ToggleButton : UserControl
    {

        public delegate void ToggleButtonHandler(bool oldValue,bool newValue);
        public event ToggleButtonHandler ToggleButtonEvent;
        public ToggleButton()
        {
            InitializeComponent();
            R1.Width = xWidth;
            R1.Height = xHeight;
            Canvas.SetLeft(R2, 1);
            Canvas.SetTop(R2, 1);
            R2.Width = 0.5 * xWidth - 1;
            R2.Height = xHeight - 2;
            Canvas.SetLeft(R3, 1);
            Canvas.SetTop(R3, 1);
            R3.Width = 0.5 * xWidth - 1;
            R3.Height = xHeight - 2;
            Canvas.SetLeft(TextBlock_OFF, xWidth * 0.5 + 2);
            Canvas.SetLeft(TextBlock_ON, 2);

            if (IsOn)
            {
                Canvas.SetLeft(R3, xWidth * 0.5);
            }
            else
            {
                Canvas.SetLeft(R3, 1);
            }
        }

        public string NameStr
        {
            get { return (string)GetValue(NameStrProperty); }
            set { SetValue(NameStrProperty, value); }
        }

        public static readonly DependencyProperty NameStrProperty =
            DependencyProperty.Register("NameStr", typeof(string), typeof(ToggleButton), new PropertyMetadata("namestr"));

        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof(bool), typeof(ToggleButton), new PropertyMetadata(false));

        public double xWidth
        {
            get { return (double)GetValue(xWidthProperty); }
            set { SetValue(xWidthProperty, value); }
        }

        public static readonly DependencyProperty xWidthProperty =
            DependencyProperty.Register("xWidth", typeof(double), typeof(ToggleButton), new PropertyMetadata(70.0));

        public double xHeight
        {
            get { return (double)GetValue(xHeightProperty); }
            set { SetValue(xHeightProperty, value); }
        }

        public static readonly DependencyProperty xHeightProperty =
            DependencyProperty.Register("xHeight", typeof(double), typeof(ToggleButton), new PropertyMetadata(30.0));

        double atime = 100;
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton != MouseButtonState.Pressed) { return; }
            IsOn = !IsOn;
            if (IsOn)
            {
                Storyboard bd = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = 1;
                da.To = xWidth * 0.5;
                da.Duration = new Duration(TimeSpan.FromMilliseconds(atime));
                Storyboard.SetTarget(da,R3);
                Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
                bd.Children.Add(da);
                bd.Begin();
                //Canvas.SetLeft(R3, xWidth * 0.5);
            }
            else
            {
                Storyboard bd = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = xWidth * 0.5;
                da.To = 1;
                da.Duration = new Duration(TimeSpan.FromMilliseconds(atime));
                Storyboard.SetTarget(da, R3);
                Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
                bd.Children.Add(da);
                bd.Begin();
                //Canvas.SetLeft(R3, 1);
            }
            ToggleButtonEvent?.Invoke(!IsOn, IsOn);
        }
    }
}
