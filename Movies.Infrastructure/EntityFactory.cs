using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure
{
    public class EntityFactory : IDbContextFactory<MoviesDbEntities>
    {
        /// <summary>
        /// This interface implementation helps something on designer time
        /// </summary>
        /// <returns>Entity Context</returns>
        public MoviesDbEntities Create()
        {
            return EntityFactory.Current;
        }

        private static MoviesDbEntities current;
        public static MoviesDbEntities Current
        {
            get
            {
                if (current == null)
                    current = new MoviesDbEntities();

                return current;
            }
        }
    }
}
