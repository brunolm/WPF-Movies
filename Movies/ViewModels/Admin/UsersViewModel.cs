using Movies.Admin;
using Movies.Domain;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Movies.ViewModels.Admin
{
    public class UsersViewModel
    {
        public UsersCollection Users { get; set; }

        public ICommand Add { get; internal set; }
        public ICommand Edit { get; internal set; }
        public ICommand Remove { get; internal set; }

        public UsersViewModel()
        {
            Users = new UsersCollection(UserService.Get());

            Add = new RelayCommand(
                (o) =>
                {
                    var userInputWindow = new UserInputWindow();

                    userInputWindow.Saved += (u) =>
                    {
                        Users.Add(u);
                    };

                    WindowHelper.OpenChildWindow(userInputWindow);
                }
            );

            Edit = new RelayCommand(
                (o) =>
                {
                    var userInputWindow = new UserInputWindow(o as User);
                    WindowHelper.OpenChildWindow(userInputWindow);
                },
                (o) =>
                {
                    var user = o as User;

                    return user != null && user.ID > 0;
                }
            );

            Remove = new RelayCommand(
                (o) =>
                {
                    var user = o as User;

                    if (user != null)
                    {
                        UserService.Remove(user);
                        Users.Remove(user);
                    }
                },
                (o) =>
                {
                    var user = o as User;

                    return user != null && user.ID > 0;
                }
            );
        }
    }
}
