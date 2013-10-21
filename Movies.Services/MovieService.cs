using Movies.Domain;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MovieService : ServiceBase<Movie>
    {
        public static IEnumerable<Movie> GetReleases()
        {
            var monthsAgo = DateTime.Now.AddMonths(-2);

            return Get().Where(o => o.ReleaseDate >= monthsAgo);
        }
    }
}
