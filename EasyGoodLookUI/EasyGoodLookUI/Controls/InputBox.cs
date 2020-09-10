using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EasyGoodLookUI
{
    public class InputBox:TextBox
    {
        static InputBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InputBox), new FrameworkPropertyMetadata(typeof(InputBox)));
        }

        public object NameStr
        {
            get { return (object)GetValue(NameStrProperty); }
            set { SetValue(NameStrProperty, value); }
        }

        public static readonly DependencyProperty NameStrProperty =
            DependencyProperty.Register("NameStr", typeof(object), typeof(InputBox));

        public object ValueStr
        {
            get { return (object)GetValue(ValueStrProperty); }
            set { SetValue(ValueStrProperty, value); }
        }

        public static readonly DependencyProperty ValueStrProperty =
            DependencyProperty.Register("ValueStr", typeof(object), typeof(InputBox));

        public SolidColorBrush BorderColor
        {
            get { return (SolidColorBrush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(SolidColorBrush), typeof(InputBox), new PropertyMetadata(new SolidColorBrush(Colors.Lime)));
    }
}
