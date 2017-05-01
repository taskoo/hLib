using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hLib.Models.ViewModels
{
    public class BookAuthorsVM
    {
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorMiddleName { get; set; }
        public string AuthorLastName{ get; set; }
        public string AuthorFullName
        {
            get
            {
                return AuthorFirstName + " "
                    + (string.IsNullOrEmpty(AuthorMiddleName) ? " " :
                    AuthorMiddleName) + " " + AuthorLastName;
            }
        }
    }
}