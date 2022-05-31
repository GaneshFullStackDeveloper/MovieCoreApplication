using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Entity
{
    public class MovieShowTime
    {
        //create table MovieShowTime(ShowId int,MovieId int references MovieModel(MovieId))
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowId { get; set; }
        [ForeignKey("movieModel")]
        public int MovieId { get; set; }
        public MovieModel movieModel { get; set; }
        [ForeignKey("theatreModel")]
        public int TheatreId { get; set; }
        public TheatreModel theatreModel { get; set; }
        public string ShowTime { get; set; }
        public string Date { get; set; }
    }
}
