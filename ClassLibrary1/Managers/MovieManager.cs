using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly:InternalsVisibleTo("UnitTest1")]

namespace ClassLibrary1
{
    public sealed class MovieManager
    {
        private readonly IImdbMovieService _imdbMovieService;
        public MovieManager(IImdbMovieService imdbMovieService)
        {
            _imdbMovieService = imdbMovieService;
        }

        public IEnumerable<ImdbMovie> GetAllMovies()
        {
            return _imdbMovieService.GetAllMovies();
        }

        public ImdbMovie GetMovieWithTitle(string title)
        {
            return _imdbMovieService.GetMovieWithTitle(title);
        }

        public IEnumerable<ImdbMovie> GetMoviesByCategory(string category)
        {
            return _imdbMovieService.GetMoviesByCategory(category);
        }
    }
}