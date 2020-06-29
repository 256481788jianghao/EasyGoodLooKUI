using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EasyGoodLookUI
{
    public class WindowEx:Window
    {
        static WindowEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowEx), new FrameworkPropertyMetadata(typeof(WindowEx)));
        }

        //#region Background
        //public Brush Background
        //{
        //    get { return (Brush)GetValue(BackgroundProperty); }
        //    set { SetValue(BackgroundProperty, value); }
        //}
        //public static readonly DependencyProperty BackgroundProperty =
        //    DependencyProperty.Register("Background", typeof(Brush), typeof(WindowEx));
        //#endregion
    }
}
