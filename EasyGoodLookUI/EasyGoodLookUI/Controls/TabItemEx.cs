﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EasyGoodLookUI
{
    public class TabItemEx:TabItem
    {
        static TabItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemEx), new FrameworkPropertyMetadata(typeof(TabItemEx)));
        }

        #region Property
        /// <summary>
        /// Icon的内容
        /// </summary>
        public object IconContent
        {
            get { return GetValue(IconContentProperty); }
            set { SetValue(IconContentProperty, value); }
        }

        public static readonly DependencyProperty IconContentProperty =
            DependencyProperty.Register("IconContent", typeof(object), typeof(TabItemEx));

        /// <summary>
        /// 是否显示Icon
        /// </summary>
        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }

        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register("ShowIcon", typeof(bool), typeof(TabItemEx));

        /// <summary>
        /// 焦点颜色
        /// </summary>
        public SolidColorBrush FocusBackground
        {
            get { return (SolidColorBrush)GetValue(FocusBackgroundProperty);}
            set { SetValue(FocusBackgroundProperty, value); }
        }

        public static readonly DependencyProperty FocusBackgroundProperty =
            DependencyProperty.Register("FocusBackground", typeof(SolidColorBrush), typeof(TabItemEx), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        #endregion
    }
}
