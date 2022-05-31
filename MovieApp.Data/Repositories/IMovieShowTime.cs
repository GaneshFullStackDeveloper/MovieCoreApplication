using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IMovieShowTime
    {
        string InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime);
        List<MovieApp.Entity.MovieShowTime> ShowMovieShowTime();
    }
}
