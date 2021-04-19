using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        public double LightWidth
        {
            get { return (double)GetValue(LightWidthProperty); }
            set { SetValue(LightWidthProperty, value); }
        }

        public static readonly DependencyProperty LightWidthProperty =
            DependencyProperty.Register("LightWidth", typeof(double), typeof(Light));

        public double LightHeight
        {
            get { return (double)GetValue(LightHeightProperty); }
            set { SetValue(LightHeightProperty, value); }
        }

        public static readonly DependencyProperty LightHeightProperty =
            DependencyProperty.Register("LightHeight", typeof(double), typeof(Light));

        public CornerRadius CRadius
        {
            get { return (CornerRadius)GetValue(CRadiusProperty); }
            set { SetValue(CRadiusProperty, value); }
        }

        public static readonly DependencyProperty CRadiusProperty =
            DependencyProperty.Register("CRadius", typeof(CornerRadius), typeof(Light));
    }
}
