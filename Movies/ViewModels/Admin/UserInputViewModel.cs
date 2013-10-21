using Movies.Domain;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Movies.ViewModels.Admin
{
    public class UserInputViewModel
    {
        public User EditingUser { get; set; }

        public IEnumerable<Role> Roles
        {
            get
            {
                return UserService.GetRoles();
            }
        }

        public ICommand Save { get; internal set; }

        public UserInputViewModel()
        {
            EditingUser = new User();

            Save = new RelayCommand(
                (o) =>
                {
                    if (UserService.Validate(EditingUser))
                    {
                        UserService.AddOrUpdate(EditingUser);
                    }
                    else
                    {
                        MessageBox.Show("Invalid user");
                    }
                });
        }
    }
}
