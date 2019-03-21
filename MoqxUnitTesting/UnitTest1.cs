using ClassLibrary1;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace MoqxUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        [Trait("Class Test", "")]
        public void MovieManager_GetAllMovies_WhenCalled_ReturnsAllMovies()
        {
            // Arrange
            var expectedMovies = GetAllExpectedMovies();

            var mockGateway = new Mock<IImdbMovieService>(MockBehavior.Strict);
            var movieManager = new MovieManager(mockGateway.Object);
            mockGateway.Setup(g => g.GetAllMovies()).Returns(expectedMovies);

            // Act
            var actualMovies = movieManager.GetAllMovies();

            // Assert
            Assert.Equal(expectedMovies.Count(), actualMovies.Count());
            // You should also assert that all movies in expected are in actual
            // and that there are no extra movies in actual that are not in actual
        }

        [Fact]
        [Trait("Class Test", "")]
        public void MovieManager_GetMoviesByCategory_WhenCalledWithValidCategory_ReturnsMoviesMatchingCategory()
        {
            // Arrange
            var category = "Sci-Fi";
            var expectedMovies = GetExpectedMoviesByCategory(category);

            var mockGateway = new Mock<IImdbMovieService>(MockBehavior.Strict);
            var movieManager = new MovieManager(mockGateway.Object);
            mockGateway
                .Setup(g => g.GetMoviesByCategory(category))
                .Returns(expectedMovies);

            // Act
            var actualMovies = movieManager.GetMoviesByCategory(category);

            // Assert
            Assert.Equal(expectedMovies.Count(), actualMovies.Count());
            // You should also assert that all movies in expected are in actual
            // and that there are no extra movies in actual that are not in actual
        }

        [Fact]
        [Trait("Class Test", "")]
        public void MovieManager_GetMoviesWithTitle_WhenTitleIsNull_Throws()
        {
            // Arrange
            string nullTitle = null;
            var mockGateway = new Mock<IImdbMovieService>(MockBehavior.Strict);
            var movieManager = new MovieManager(mockGateway.Object);
            mockGateway
                .Setup(g => g.GetMovieWithTitle(nullTitle))
                .Throws(new MovieTitleNullOrEmptyException($"The title: {nullTitle} is not a valid Title"));

            // Act
            try
            {
                var actualMovies = movieManager.GetMovieWithTitle(nullTitle);
                throw new XunitException("We were expecting a MovieTitleNullOrEmptyException, but no exception was thrown");
            }
            catch (MovieTitleNullOrEmptyException)
            {
                // Assert
                mockGateway.Verify(g => g.GetMovieWithTitle(nullTitle));
            }
        }

        [Fact]
        [Trait("Class Test", "")]
        public void MovieManager_GetMoviesWithTitle_WhenTitleIsEmpty_Throws()
        {
            // Arrange
            string emptyTitle = string.Empty;
            var mockGateway = new Mock<IImdbMovieService>(MockBehavior.Strict);
            var movieManager = new MovieManager(mockGateway.Object);
            mockGateway
                .Setup(g => g.GetMovieWithTitle(emptyTitle))
                .Returns<string>(title =>
                {
                    // You don't ever want to do this (implement logic in your mocks)
                    // This is just to show that you can do it this way in case you
                    // have to
                    if (title.Length == 0)
                    {
                        throw new MovieTitleNullOrEmptyException($"The title: {emptyTitle} is not a valid Title");
                    }
                    else
                    {
                        return GetExpectedMovieByTitle(title);
                    }
                });

            // Act
            try
            {
                var actualMovies = movieManager.GetMovieWithTitle(emptyTitle);
                throw new XunitException("We were expecting a MovieTitleNullOrEmptyException, but no exception was thrown");
            }
            catch (MovieTitleNullOrEmptyException e)
            {
                Assert.Contains("not a valid Title", e.Message);
            }
        }

        private static IEnumerable<ImdbMovie> GetAllExpectedMovies()
        {
            yield return new ImdbMovie("Star Wars Episode IV: A New Hope", "Sci-Fi", 1977, "StarWarsEpisodeIV.jpg");
            yield return new ImdbMovie("Star Wars Episode V: The Empire Strikes Back", "Sci-Fi", 1980, "StarWarsEpisodeV.jpg");
            yield return new ImdbMovie("Star Wars Episode VI: Return of the Jedi", "Sci-Fi", 1983, "StarWarsEpisodeVI.jpg");
            yield return new ImdbMovie("Star Wars: Episode I: The Phantom Menace", "Sci-Fi", 1999, "StarWarsEpisodeI.jpg");
            yield return new ImdbMovie("Star Wars Episode II: Attack of the Clones", "Sci-Fi", 2002, "StarWarsEpisodeII.jpg");
            yield return new ImdbMovie("Star Wars: Episode III: Revenge of the Sith", "Sci-Fi", 2005, "StarWarsEpisodeIII.jpg");
            yield return new ImdbMovie("Olympus Has Fallen", "Action", 2013, "Olympus_Has_Fallen_poster.jpg");
            yield return new ImdbMovie("G.I. Joe: Retaliation", "Action", 2013, "GIJoeRetaliation.jpg");
            yield return new ImdbMovie("Jack the Giant Slayer", "Action", 2013, "jackgiantslayer4.jpg");
            yield return new ImdbMovie("Drive", "Action", 2011, "FileDrive2011Poster.jpg");
            yield return new ImdbMovie("Sherlock Holmes", "Action", 2009, "FileSherlock_Holmes2Poster.jpg");
            yield return new ImdbMovie("The Girl with the Dragon Tatoo", "Drama", 2011, "FileThe_Girl_with_the_Dragon_Tattoo_Poster.jpg");

        }

        private static IEnumerable<ImdbMovie> GetExpectedMoviesByCategory(string category)
        {
            return GetAllExpectedMovies().Where(m => m.Category == category);
        }

        private ImdbMovie GetExpectedMovieByTitle(string title)
        {
            return GetAllExpectedMovies().Where(m => m.Title == title).Single();
        }
    }
}
