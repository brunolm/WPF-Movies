using Movies.Domain;
using Movies.Services;
using System.Collections.ObjectModel;

namespace Movies.ViewModels
{
    public class MoviesCollection : ObservableCollection<Movie>
    {
        public MoviesCollection()
            : base(MovieService.GetReleases())
        {
        }
    }
}
