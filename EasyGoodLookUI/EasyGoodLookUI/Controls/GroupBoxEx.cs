using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasyGoodLookUI
{
    public class GroupBoxEx:GroupBox
    {
        static GroupBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GroupBoxEx), new FrameworkPropertyMetadata(typeof(GroupBoxEx)));
        }
    }
}
