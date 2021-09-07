using System;
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
    /// SelfMediumButton.xaml 的交互逻辑
    /// </summary>
    public partial class SelfMediumButton : UserControl
    {
        public SelfMediumButton()
        {
            InitializeComponent();
            R1.Width = xWidth;
            R1.Height = xHeight;

            Canvas.SetLeft(R2, 1);
            Canvas.SetTop(R2, 1);
            R2.Width = xWidth / 3 - 1;
            R2.Height = xHeight - 2;

            Canvas.SetLeft(R4, xWidth / 3);
            Canvas.SetTop(R4, 1);
            R4.Width = xWidth / 3;
            R4.Height = xHeight - 2;

            Canvas.SetLeft(R3, xWidth / 3);
            Canvas.SetTop(R3, 1);
            R3.Width = xWidth / 3;
            R3.Height = xHeight - 2;

            Canvas.SetLeft(TextBlock_OFF, 2 * xWidth / 3 + 2);
            Canvas.SetLeft(TextBlock_ON, 2);
        }

        public enum SelfMediumButtonPos
        {
            LEFT,
            MEDIUM,
            RIGHT
        }
        public delegate void SelfMediumButtonHandler(SelfMediumButtonPos pos);
        public event SelfMediumButtonHandler SelfMediumButtonEvent;

        public string NameStr
        {
            get { return (string)GetValue(NameStrProperty); }
            set { SetValue(NameStrProperty, value); }
        }

        public static readonly DependencyProperty NameStrProperty =
            DependencyProperty.Register("NameStr", typeof(string), typeof(SelfMediumButton), new PropertyMetadata("namestr"));
        public string RightText
        {
            get { return (string)GetValue(RightTextProperty); }
            set { SetValue(RightTextProperty, value); }
        }

        public static readonly DependencyProperty RightTextProperty =
            DependencyProperty.Register("RightText", typeof(string), typeof(SelfMediumButton), new PropertyMetadata("正"));

        public string LeftText
        {
            get { return (string)GetValue(LeftTextProperty); }
            set { SetValue(LeftTextProperty, value); }
        }

        public static readonly DependencyProperty LeftTextProperty =
            DependencyProperty.Register("LeftText", typeof(string), typeof(SelfMediumButton), new PropertyMetadata("反"));

        public double xWidth
        {
            get { return (double)GetValue(xWidthProperty); }
            set { SetValue(xWidthProperty, value); }
        }

        public static readonly DependencyProperty xWidthProperty =
            DependencyProperty.Register("xWidth", typeof(double), typeof(SelfMediumButton), new PropertyMetadata(90.0));

        public double xHeight
        {
            get { return (double)GetValue(xHeightProperty); }
            set { SetValue(xHeightProperty, value); }
        }

        public static readonly DependencyProperty xHeightProperty =
            DependencyProperty.Register("xHeight", typeof(double), typeof(SelfMediumButton), new PropertyMetadata(30.0));

        double atime = 100;
        int pos_index = 1;
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) { return; }
            Point p = e.GetPosition(Canvas_Main);
            if(p.X < xWidth * 0.3){
                pos_index = 0;
                Storyboard bd = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = xWidth / 3;
                da.To = 1;
                da.Duration = new Duration(TimeSpan.FromMilliseconds(atime));
                Storyboard.SetTarget(da, R3);
                Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
                bd.Children.Add(da);
                bd.Begin();
                SelfMediumButtonEvent?.Invoke(SelfMediumButtonPos.LEFT);
            }
            if (p.X > 2*xWidth * 0.3)
            {
                pos_index = 2;
                Storyboard bd = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = xWidth / 3;
                da.To = 2 * xWidth / 3 - 1;
                da.Duration = new Duration(TimeSpan.FromMilliseconds(atime));
                Storyboard.SetTarget(da, R3);
                Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
                bd.Children.Add(da);
                bd.Begin();
                SelfMediumButtonEvent?.Invoke(SelfMediumButtonPos.RIGHT);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Released) { return; }
            if(pos_index == 0)
            {
                Storyboard bd = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = 1;
                da.To = xWidth / 3;
                da.Duration = new Duration(TimeSpan.FromMilliseconds(atime));
                Storyboard.SetTarget(da, R3);
                Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
                bd.Children.Add(da);
                bd.Begin();
            }
            if (pos_index == 2)
            {
                Storyboard bd = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = 2 * xWidth / 3 - 1;
                da.To = xWidth / 3;
                da.Duration = new Duration(TimeSpan.FromMilliseconds(atime));
                Storyboard.SetTarget(da, R3);
                Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.LeftProperty));
                bd.Children.Add(da);
                bd.Begin();
            }

            pos_index = 1;
            SelfMediumButtonEvent?.Invoke(SelfMediumButtonPos.MEDIUM);
        }
    }
}
