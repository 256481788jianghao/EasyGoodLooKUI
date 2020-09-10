using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EasyGoodLookUI
{
    public class Light:Label
    {
        static Light()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Light), new FrameworkPropertyMetadata(typeof(Light)));
        }

        public bool IsRed
        {
            get { return (bool)GetValue(IsRedProperty); }
            set { SetValue(IsRedProperty, value); }
        }

        public static readonly DependencyProperty IsRedProperty =
            DependencyProperty.Register("IsRed", typeof(bool), typeof(Light));
    }
}
