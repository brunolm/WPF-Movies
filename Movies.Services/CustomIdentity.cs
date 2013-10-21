using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity()
        {
        }

        public string AuthenticationType
        {
            get { return "Default"; }
        }

        public bool IsAuthenticated
        {
            get { return UserService.CurrentUser != null; }
        }

        public string Name
        {
            get { return UserService.CurrentUser != null ? UserService.CurrentUser.Name : "Anonymous"; }
        }
    }
}
