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

        public object UtiStr
        {
            get { return (object)GetValue(UtiStrProperty); }
            set { SetValue(UtiStrProperty, value); }
        }

        public static readonly DependencyProperty UtiStrProperty =
            DependencyProperty.Register("UtiStr", typeof(object), typeof(InputBox));

        public object ValueStr
        {
            get { return (object)GetValue(ValueStrProperty); }
            set { SetValue(ValueStrProperty, value); }
        }

        public static readonly DependencyProperty ValueStrProperty =
            DependencyProperty.Register("ValueStr", typeof(object), typeof(InputBox));

        public string NameWidth
        {
            get { return (string)GetValue(NameWidthProperty); }
            set { SetValue(NameWidthProperty, value); }
        }

        public static readonly DependencyProperty NameWidthProperty =
            DependencyProperty.Register("NameWidth", typeof(string), typeof(InputBox));

        public string ValueWidth
        {
            get { return (string)GetValue(ValueWidthProperty); }
            set { SetValue(ValueWidthProperty, value); }
        }

        public static readonly DependencyProperty ValueWidthProperty =
            DependencyProperty.Register("ValueWidth", typeof(string), typeof(InputBox));

        public string UtiWidth
        {
            get { return (string)GetValue(UtiWidthProperty); }
            set { SetValue(UtiWidthProperty, value); }
        }

        public static readonly DependencyProperty UtiWidthProperty =
            DependencyProperty.Register("UtiWidth", typeof(string), typeof(InputBox));

        public SolidColorBrush BorderColor
        {
            get { return (SolidColorBrush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(SolidColorBrush), typeof(InputBox), new PropertyMetadata(new SolidColorBrush(Colors.Lime)));
    }
}
