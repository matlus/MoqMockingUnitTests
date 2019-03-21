using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ImdbMovieService : IImdbMovieService
    {
        public IEnumerable<ImdbMovie> GetAllMovies()
        {
            return null;
        }

        public ImdbMovie GetMovieWithTitle(string title)
        {
            EnsureTitleIsValid(title);
            return null;
        }

        public IEnumerable<ImdbMovie> GetMoviesByCategory(string category)
        {
            return null;
        }

        /// <summary>
        /// This method would normally be in the Manager
        /// However, for the sake of this example, I've moved
        /// it here since we're Testing the Manager and mocking
        /// this class
        /// </summary>
        /// <param name="title"></param>
        private static void EnsureTitleIsValid(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new MovieTitleNullOrEmptyException($"The title: {title} is not a valid Title");
            }
            else if (title.Length > 30)
            {
                throw new InvalidMovieTitleException($"The lenght of the title: ({title}), exceeds the maximum allowed length for a Title");
            }
        }

    }
}
