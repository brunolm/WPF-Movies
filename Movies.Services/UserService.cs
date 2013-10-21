using Movies.Domain;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class UserService : ServiceBase<User>
    {
        public static User CurrentUser { get; private set; }

        public static bool Authenticate(string username, string password)
        {
            var user = EntityFactory.Current.Users.FirstOrDefault(o => o.Username == username && o.Password == password);

            if (user != null)
            {
                CurrentUser = user;
                Thread.CurrentPrincipal = new CustomPrincipal();
                return true;
            }
            
            return false;
        }

        public static void Logoff()
        {
            UserService.CurrentUser = null;
        }

        public static IEnumerable<Role> GetRoles()
        {
            return EntityFactory.Current.Roles.OrderBy(o => o.Name).ToList();
        }

        public static bool Validate(User u)
        {
            return u != null
                && u.Name != null
                && u.Username != null
                && u.Password != null
                && u.RoleID > 0;
        }
    }
}
