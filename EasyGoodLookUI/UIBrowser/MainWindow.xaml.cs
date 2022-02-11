using EasyGoodLookUI;
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

namespace UIBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowEx
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Data();
        }

        private void C_Test_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox item = (ComboBox)e.OriginalSource;
            MessageBox.Show(item.SelectedIndex.ToString());
        }

        private void SwitchButton_Test_Click(object sender, RoutedEventArgs e)
        {
            SwitchButton_Test.IsOn = !SwitchButton_Test.IsOn;
        }

        class Data
        {
            public double Test { get; set; } = 123.4567;
            public string TestStr { get; set; } = "jianghao";
        }

        void JoyStickTest(double x,double y)
        {
            Console.WriteLine(x + " " + y);
        }

        private void WindowEx_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void SelfMediumButton_SelectButton(object sender, RoutedEventArgs e)
        {
            SelfMediumButton button = (SelfMediumButton)sender;
            Console.WriteLine(button.BPos.ToString());
        }

        private void JS_PosChange(object sender, RoutedEventArgs e)
        {
            JoyStickPanelEventArgs args = (JoyStickPanelEventArgs)e;
            Console.WriteLine(args.CurPoint.X + " " + args.CurPoint.Y);
        }

        private void ToggleButton_ToggleChange(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            bool test = button.IsOn;
        }
    }
}
