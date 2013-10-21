using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal() { }

        public IIdentity Identity
        {
            get
            {
                return new CustomIdentity();
            }
        }

        public bool IsInRole(string role)
        {
            if (UserService.CurrentUser == null)
                return false;

            return String.Equals(UserService.CurrentUser.Role.Name, role, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
