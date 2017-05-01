using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hLib.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        [Required]
        [Display(Name = "Language")]
        [StringLength(50, ErrorMessage = "Language cannot be more than 50 characters.")]
        public string LanguageName { get; set; }
    }
}