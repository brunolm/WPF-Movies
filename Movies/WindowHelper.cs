using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Movies
{
    public static class WindowHelper
    {
        public static bool? OpenChildWindow<T>(T window)
            where T : Window
        {
            return OpenChildWindow<T, Window>(window, null);
        }

        public static bool? OpenChildWindow<T, TOwner>(T window, TOwner owner)
            where T : Window
            where TOwner: Window
        {
            if (owner != null)
                window.Owner = owner;

            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            return window.ShowDialog();
        }
    }
}
