using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowTimeController : ControllerBase
    {
        MovieShowTimeService _MovieShowTimeService;
        public MovieShowTimeController(MovieShowTimeService movieShowTime)
        {
            _MovieShowTimeService = movieShowTime;
        }
        [HttpGet("ShowMovieTimeList")]
        public IActionResult ShowMovieTimeList()
        {
            return Ok(_MovieShowTimeService.ShowMovieTimeList());
        }
        [HttpPost("InsertMovieShowTime")]
        public IActionResult InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime)
        {
            return Ok(_MovieShowTimeService.InsertMovieShowTime(movieShowTime));
        }
    }
}
