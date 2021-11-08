using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // a
using System.ComponentModel.DataAnnotations.Schema;//a
using OperaWebSite.Validations;//a

namespace OperaWebSite.Models
{
    [Table("Opera")]// EF --> DB
    public class Opera
    {
        public int OperaId { get; set; }
        [Required(ErrorMessage ="Title is required")]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        public string Composer { get; set; }
        // validación personalizada
        [CheckValidYear]
        public int Year { get; set; }
    }
}