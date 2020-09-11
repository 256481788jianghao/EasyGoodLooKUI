using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EasyGoodLookUI
{
    public class ShowComboBox:ComboBox
    {
        static ShowComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ShowComboBox), new FrameworkPropertyMetadata(typeof(ShowComboBox)));
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


        #region Commands
        //public ICommand SelectionChangeCB
        //{
        //    get { return (ICommand)GetValue(SelectionChangeCBProperty); }
        //    set { SetValue(SelectionChangeCBProperty, value); }
        //}

        //public static readonly DependencyProperty SelectionChangeCBProperty =
        //    DependencyProperty.Register("SelectionChangeCB", typeof(ICommand), typeof(WindowEx), new PropertyMetadata(new InternalCommand(OnSelectedChangeCommandExecute)));

        //private static void OnSelectedChangeCommandExecute(object obj)
        //{
        //    ComboBox item = (ComboBox)obj;
        //}

        //private class InternalCommand : ICommand
        //{
        //    private Action<Object> m_ExeAction;
        //    private Func<object, bool> m_CanExe;
        //    public event EventHandler CanExecuteChanged;

        //    public InternalCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc = null)
        //    {
        //        m_ExeAction = executeAction;
        //        m_CanExe = canExecuteFunc;
        //    }

        //    public bool CanExecute(object parameter)
        //    {
        //        return m_CanExe?.Invoke(parameter) ?? true;
        //    }

        //    public void Execute(object parameter)
        //    {
        //        m_ExeAction?.Invoke(parameter);
        //    }
        //}
        #endregion
    }
}
