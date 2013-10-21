using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.ViewModels.Admin
{
    public class UsersCollection : ObservableCollection<User>
    {
        public UsersCollection(IEnumerable<User> users)
            : base(users)
        {
            
        }
    }
}
