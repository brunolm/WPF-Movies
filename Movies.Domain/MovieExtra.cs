using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain
{
    public partial class Movie
    {
        public string Photo
        {
            get
            {
                return String.Format(@"Files\Movie\Covers\{0}.jpg", ID);
            }
        }
    }
}
