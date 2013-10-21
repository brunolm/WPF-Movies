using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Movies.ViewModels
{
    public class MainViewModel
    {
        public MoviesCollection Movies { get; set; }

        public ICommand SortCommand { get; internal set; }

        public SortDescriptionCollection MovieSortDescriptions { get; set; }

        public MainViewModel()
        {
            Movies = new MoviesCollection();

            SortCommand = new RelayCommand((o) =>
            {
                MovieSortDescriptions.Clear();

                var parameter = o as string;

                switch (parameter)
                {
                    case "ASC":
                        MovieSortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                        break;
                    case "DESC":
                        MovieSortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
                        break;
                    case "None":
                    default:
                        break;
                }
            });
        }
    }
}
