using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class MovieShowTimeService
    {
        IMovieShowTime _movieShowTime;
        public MovieShowTimeService(IMovieShowTime movieShowTime)
        {
            _movieShowTime = movieShowTime;
        }
        public string InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime)
        {
           return _movieShowTime.InsertMovieShowTime(movieShowTime);
        }
        public List<MovieApp.Entity.MovieShowTime> ShowMovieTimeList()
        {
            return _movieShowTime.ShowMovieShowTime();
        }
    }
}
