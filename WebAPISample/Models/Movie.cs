using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPISample.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Genre")]
        public string Genre { get; set; }
        [DisplayName("Director")]
        public string Director { get; set; }
    }
}