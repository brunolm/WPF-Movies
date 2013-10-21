using Movies.Admin;
using Movies.Domain;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Movies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Movies.ViewModels.MainViewModel).MovieSortDescriptions = lstMovies.Items.SortDescriptions;
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loginResult = WindowHelper.OpenChildWindow(new UsersWindow());
            }
            catch (SecurityException)
            {
                MessageBox.Show("Only admins can manage users");
            }

        }

        private void btnMovies_Click(object sender, RoutedEventArgs e)
        {
            //var loginResult = OpenChildWindow(new MoviesWindow());

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginResult = WindowHelper.OpenChildWindow(new LoginWindow(), this);

            if (loginResult.HasValue && loginResult.Value)
            {
                btnLogin.Click -= btnLogin_Click;
                btnLogin.Click += btnLogoff_Click;
                btnLogin.Header = String.Format("Logged in as {0}, logoff.", Thread.CurrentPrincipal.Identity.Name);
            }
        }

        private void btnLogoff_Click(object sender, RoutedEventArgs e)
        {
            UserService.Logoff();

            btnLogin.Header = "Login";
            btnLogin.Click += btnLogin_Click;
            btnLogin.Click -= btnLogoff_Click;
        }
    }
}
