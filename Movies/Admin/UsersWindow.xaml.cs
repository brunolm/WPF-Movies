using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Movies.Admin
{
    /// <summary>
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    //[PrincipalPermission(SecurityAction.Demand, Role="Admin")]
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
        }
    }
}
