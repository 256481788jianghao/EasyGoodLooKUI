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
    /// ShowComboBoxEx.xaml 的交互逻辑
    /// </summary>
    public partial class ShowComboBoxEx : UserControl
    {
        public ShowComboBoxEx()
        {
            InitializeComponent();
        }

        public object NameStr
        {
            get { return (object)GetValue(NameStrProperty); }
            set { SetValue(NameStrProperty, value); }
        }

        public static readonly DependencyProperty NameStrProperty =
            DependencyProperty.Register("NameStr", typeof(object), typeof(ShowComboBox));

        public string ItemArray
        {
            get { return (string)GetValue(ItemArrayProperty); }
            set { SetValue(ItemArrayProperty, value); }
        }

        public static readonly DependencyProperty ItemArrayProperty =
            DependencyProperty.Register("ItemArray", typeof(string), typeof(ShowComboBox));


        public SolidColorBrush BorderColor
        {
            get { return (SolidColorBrush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(SolidColorBrush), typeof(ShowComboBox), new PropertyMetadata(new SolidColorBrush(Colors.Lime)));
    }
}
