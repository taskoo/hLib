using hLib.Models.ValidatonRules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hLib.Models
{
    public class Book
    {
        public Book() {
            this.Authors = new HashSet<Author>();
        }

        public int BookId { get; set; }

        [Required(ErrorMessage = "You cannot leave filed for book title empty!")]
        [StringLength(100, ErrorMessage = "Title cannot be more than 100 characters.")]
        public string Title { get; set; }

        [Display(Name = "ISBN")]
        [StringLength(17)]
        [Index(IsUnique = true)]
        [ISBNValidation]
        public string ISBN { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be more than 500 characters.")]
        public string Description { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage = "Language field is mandatory!")]
        public int LanguageId { get; set; }          
        public virtual Language Language { get; set; }

        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
                
        public virtual ICollection<Author> Authors { get; set; }
    }
}