using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace EasyGoodLookUI
{
    public class WindowEx:Window
    {
        static WindowEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowEx), new FrameworkPropertyMetadata(typeof(WindowEx)));
        }

        #region Property
        /// <summary>
        /// MainHeader的高度
        /// </summary>
        public string MainHeaderHeight
        {
            get { return (string)GetValue(MainHeaderHeightProperty); }
            set { SetValue(MainHeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty MainHeaderHeightProperty =
            DependencyProperty.Register("MainHeaderHeight", typeof(string), typeof(WindowEx));

        /// <summary>
        /// SubHeader的高度
        /// </summary>
        public string SubHeaderHeight
        {
            get { return (string)GetValue(SubHeaderHeightProperty); }
            set { SetValue(SubHeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty SubHeaderHeightProperty =
            DependencyProperty.Register("SubHeaderHeight", typeof(string), typeof(WindowEx));

        /// <summary>
        /// IconArea的宽度
        /// </summary>
        public string IconAreaWidth
        {
            get { return (string)GetValue(IconAreaWidthProperty); }
            set { SetValue(IconAreaWidthProperty, value); }
        }

        public static readonly DependencyProperty IconAreaWidthProperty =
            DependencyProperty.Register("IconAreaWidth", typeof(string), typeof(WindowEx));

        /// <summary>
        /// Title的background的颜色
        /// </summary>
        public SolidColorBrush TitleBackground
        {
            get { return (SolidColorBrush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }

        public static readonly DependencyProperty TitleBackgroundProperty =
            DependencyProperty.Register("TitleBackground", typeof(SolidColorBrush), typeof(WindowEx));
        #endregion

        #region Commands
        public static readonly DependencyProperty MinimizeCommandProperty =
            DependencyProperty.Register("MinimizeCommand", typeof(ICommand), typeof(WindowEx), new PropertyMetadata(new InternalCommand(OnMinimizeCommandExecute)));

        public static readonly DependencyProperty MaximizeCommandProperty =
            DependencyProperty.Register("MaximizeCommand", typeof(ICommand), typeof(WindowEx), new PropertyMetadata(new InternalCommand(OnMaximizeCommandExecute)));

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(WindowEx), new PropertyMetadata(new InternalCommand(OnCloseCommandExecute)));

        private static void OnMinimizeCommandExecute(object obj)
        {
            var windowX = (obj as WindowEx);
            windowX.Minimize();
        }

        private static void OnMaximizeCommandExecute(object obj)
        {
            var window = (obj as WindowEx);
            window.MaximizeOrNormalmize();
        }


        private static void OnCloseCommandExecute(object obj)
        {
            var windowX = (obj as WindowEx);
            windowX.Close();
        }

        public void Minimize()
        {
            WindowState = WindowState.Minimized;
        }

        public void Maximize()
        {
            WindowState = WindowState.Maximized;
        }

        public void Normalmize()
        {
            WindowState = WindowState.Normal;
        }

        public void MaximizeOrNormalmize()
        {
            if (WindowState == WindowState.Maximized)
                Normalmize();
            else
                Maximize();
        }

        private class InternalCommand : ICommand
        {
            private Action<Object> m_ExeAction;
            private Func<object, bool> m_CanExe;
            public event EventHandler CanExecuteChanged;

            public InternalCommand(Action<object> executeAction, Func<object,bool> canExecuteFunc = null)
            {
                m_ExeAction = executeAction;
                m_CanExe = canExecuteFunc;
            }

            public bool CanExecute(object parameter)
            {
                return m_CanExe?.Invoke(parameter) ?? true;
            }

            public void Execute(object parameter)
            {
                m_ExeAction?.Invoke(parameter);
            }
        }
        #endregion

    }
}
