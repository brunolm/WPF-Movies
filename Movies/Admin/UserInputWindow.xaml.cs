using Movies.Domain;
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
using System.Windows.Shapes;

namespace Movies.Admin
{
    /// <summary>
    /// Interaction logic for UserInputWindow.xaml
    /// </summary>
    public partial class UserInputWindow : Window
    {
        public User EditingUser { get; set; }

        public UserInputWindow()
            : this(null)
        {
        }

        public UserInputWindow(User user)
        {
            EditingUser = user;

            InitializeComponent();

            if (user != null)
                this.Title = "Editing " + user.Name;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
