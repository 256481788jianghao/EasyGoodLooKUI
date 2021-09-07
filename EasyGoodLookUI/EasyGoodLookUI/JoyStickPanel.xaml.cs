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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyGoodLookUI
{
    /// <summary>
    /// JoyStickPanel.xaml 的交互逻辑
    /// </summary>
    public partial class JoyStickPanel : UserControl
    {
        Point m_Med;
        public JoyStickPanel()
        {
            InitializeComponent();  
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(JoyStickPanel),new PropertyMetadata(100.0));

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            m_Med = new Point(Radius * 0.5, Radius * 0.5);
            Line_Col.X1 = m_Med.X;
            Line_Col.Y1 = 0;
            Line_Col.X2 = m_Med.X;
            Line_Col.Y2 = Radius;
            Line_Row.X1 = 0;
            Line_Row.Y1 = m_Med.Y;
            Line_Row.X2 = Radius;
            Line_Row.Y2 = m_Med.Y;
            Canvas.SetLeft(Ellipse_Arch, Radius * 0.5 - 10);
            Canvas.SetTop(Ellipse_Arch, Radius * 0.5 - 10);
            Canvas.SetLeft(Ellipse_Med, Radius * 0.5 - 5);
            Canvas.SetTop(Ellipse_Med, Radius * 0.5 - 5);
        }

        bool m_StartNotify = false;

        private void Canvas_Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                m_StartNotify = true;
                Point p = e.GetPosition(Canvas_Main);
                Point p2 = ComputeXY(p);
                JoyStickPanelEventArgs args = new JoyStickPanelEventArgs(PosChangeEvent, this, p2);
                RaiseEvent(args);
                //Console.WriteLine(p2.X + " " + p2.Y);
                Canvas.SetLeft(Ellipse_Arch, p.X - 10);
                Canvas.SetTop(Ellipse_Arch, p.Y - 10);
            }
            if (e.ChangedButton == MouseButton.Right)
            {
                Canvas.SetLeft(Ellipse_Arch, Radius * 0.5 - 10);
                Canvas.SetTop(Ellipse_Arch, Radius * 0.5 - 10);
                JoyStickPanelEventArgs args = new JoyStickPanelEventArgs(PosChangeEvent, this, new Point(0, 0));
                RaiseEvent(args);
            }
        }

        private Point ComputeXY(Point ClickPoint)
        {
            double x = (ClickPoint.X - m_Med.X) * 2 / Radius;
            if(x < -1)
            {
                x = -1;
            }
            if(x > 1)
            {
                x = 1;
            }
            double y = (ClickPoint.Y - m_Med.Y) * 2 / Radius;
            if (y < -1)
            {
                y = -1;
            }
            if (y > 1)
            {
                y = 1;
            }
            return new Point(x, -y);
        }

        private void Canvas_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_StartNotify)
            {

                Point p = e.GetPosition(Canvas_Main);
                Point p2 = ComputeXY(p);
                JoyStickPanelEventArgs args = new JoyStickPanelEventArgs(PosChangeEvent, this, p2);
                RaiseEvent(args);
                if ((p2.X*p2.X+p2.Y*p2.Y)>1)
                { 
                    return;
                }
                Canvas.SetLeft(Ellipse_Arch, p.X - 10);
                Canvas.SetTop(Ellipse_Arch, p.Y - 10);
            }
        }

        private void Canvas_Main_MouseUp(object sender, MouseButtonEventArgs e)
        {
            m_StartNotify = false;
            Canvas.SetLeft(Ellipse_Arch, Radius * 0.5 - 10);
            Canvas.SetTop(Ellipse_Arch, Radius * 0.5 - 10);
            JoyStickPanelEventArgs args = new JoyStickPanelEventArgs(PosChangeEvent, this, new Point(0, 0));
            RaiseEvent(args);
        }

        public static readonly RoutedEvent PosChangeEvent = EventManager.RegisterRoutedEvent("PosChangeEvent", RoutingStrategy.Bubble, typeof(EventHandler<JoyStickPanelEventArgs>), typeof(JoyStickPanel));

        public event RoutedEventHandler PosChange
        {
            //将路由事件添加路由事件处理程序
            add { AddHandler(PosChangeEvent, value); }
            //从路由事件处理程序中移除路由事件
            remove { RemoveHandler(PosChangeEvent, value); }
        }
    }
}
