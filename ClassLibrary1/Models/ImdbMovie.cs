using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public sealed class ImdbMovie
    {
        public string Title { get; }
        public string Category { get; }
        public int Year { get; }
        public string ImageUrl { get; }

        public ImdbMovie(string title, string category, int year, string imageUrl)
        {
            Title = title;
            Category = category;
            Year = year;
            ImageUrl = imageUrl;
        }
    }
}
