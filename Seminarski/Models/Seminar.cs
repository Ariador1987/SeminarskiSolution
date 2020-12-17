using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Seminarski.Models;

namespace Seminarski.Models
{
    [Table("Seminari")]
    public class Seminar
    {
        [Key]
        public int SeminarID { get; set; }

        [Required]
        [DisplayName("Popunjen")]
        public bool JePopunjen { get; set; } = false;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Datum je obavezan")]
        public DateTime Datum { get; set; }

        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2-100 znakova")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Broj polaznika je obavezan")]
        [Range(1,11, ErrorMessage = "1-11 polaznika")]
        [DisplayName("Broj polaznika")]
        public int BrojPolaznika { get; set; }
        
        public IList<Predbiljezba> Predbiljezba { get; set; }
    }
}