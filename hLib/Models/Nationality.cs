using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hLib.Models
{
    public class Nationality
    {
        public Nationality()
        {
            this.Authors = new HashSet<Author>();
        }
        public int NationalityId { get; set; }
        [Required]
        [Display(Name = "Nationality")]
        [StringLength(50, ErrorMessage = "Nationality cannot be more than 50 characters.")]
        public string NationalityName { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}