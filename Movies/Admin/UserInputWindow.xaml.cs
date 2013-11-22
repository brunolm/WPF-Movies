using Movies.Domain;
using Movies.ViewModels.Admin;
using System;
using System.Windows;

namespace Movies.Admin
{
    /// <summary>
    /// Interaction logic for UserInputWindow.xaml
    /// </summary>
    public partial class UserInputWindow : Window
    {
        public User EditingUser { get; set; }

        public UserInputViewModel ViewModel
        {
            get
            {
                return DataContext as UserInputViewModel;
            }
        }

        public delegate void OnSaved(User u);
        public event OnSaved Saved;

        public UserInputWindow()
            : this(null)
        {
        }

        public UserInputWindow(User user)
        {
            DataContext = new UserInputViewModel();

            if (user == null)
                user = new User();

            EditingUser = user;
            ViewModel.EditingUser = user;

            InitializeComponent();

            ViewModel.Saved += (u) =>
            {
                if (Saved != null)
                    Saved(u);
            };

            ViewModel.Closing += (s, e) =>
            {
                this.Close();
            };

            if (user != null && !String.IsNullOrWhiteSpace(user.Name))
            {
                this.Title = "Editing " + user.Name;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Closing != null)
            {
                ViewModel.Closing(sender, EventArgs.Empty);
            }

            this.EditingUser = null;
            this.Close();
        }
    }
}
