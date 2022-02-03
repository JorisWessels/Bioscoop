﻿namespace Bioscoop
{
    public class Movie
    {
        private string _title;
        private IList<MovieScreening> _movieScreenings;

        public Movie(string title)
        {
            _title = title;
            _movieScreenings = new List<MovieScreening>();
        }

        public void addScreening(MovieScreening screening)
        {
            _movieScreenings.Add(screening);
        }

        public string toString()
        {
            return _title.ToString();
        }
    }
}
