using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public interface IImdbMovieService
    {
        IEnumerable<ImdbMovie> GetAllMovies();
        ImdbMovie GetMovieWithTitle(string title);
        IEnumerable<ImdbMovie> GetMoviesByCategory(string category);
    }
}
