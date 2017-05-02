using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hLib.Models
{
    public class Author
    {
        public Author(){
            this.Books = new HashSet<Book>();
        }
        public int AuthorId { get; set; }
        [Required(ErrorMessage ="First name is required!")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters.")]
        public string AuthorFirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters.")]
        public string AuthorMiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters.")]
        public string AuthorLastName { get; set; }

        [Required(ErrorMessage = "Nationality can not be empty!")]
        public int NationalityId { get; set; }

        [Display(Name = "Nationality")]
        public virtual Nationality Nationality { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        [Display(Name = "Author")]
        public string FullName
        {
            get
            {
                return AuthorFirstName+" "
                    + (string.IsNullOrEmpty(AuthorMiddleName) ? " " :
                    AuthorMiddleName) + " " +AuthorLastName;
            }
        }

        [Display(Name = "Author")]
        public string FormalName
        {
            get
            {
                return AuthorFirstName + ", " + AuthorLastName
                    + (string.IsNullOrEmpty(AuthorMiddleName) ? "" :
                    (" " + (char?)AuthorMiddleName[0] + ".").ToUpper());
            }
        }
    }
}