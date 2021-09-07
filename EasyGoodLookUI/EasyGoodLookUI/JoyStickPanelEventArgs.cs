using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyGoodLookUI
{
    public class JoyStickPanelEventArgs : RoutedEventArgs
    {
        public JoyStickPanelEventArgs(RoutedEvent routedEvent, object source,Point p) : base(routedEvent, source)
        {
            CurPoint = p;
        }

        public Point CurPoint { get; set; }

    }
}
