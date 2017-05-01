using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hLib.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        [Display(Name = "Genre")]
        [StringLength(50, ErrorMessage = "Genre cannot be more than 50 characters.")]
        public string GenreName { get; set; }
    }
}