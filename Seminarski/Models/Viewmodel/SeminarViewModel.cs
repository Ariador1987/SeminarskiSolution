using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Seminarski.Models.Viewmodel
{
    public class SeminarViewModel
    {

        [Required]
        [DisplayName("Popunjen")]
        public bool JePopunjen { get; set; } = false;

        [Required(ErrorMessage = "Datum je obavezan")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

        
        [DisplayName("Broj polaznika")]
        public int TrenutniBrojPolaznika { get; set; }

        [DisplayName("Max polaznika")]
        [Range(1, 11, ErrorMessage = "1-11 polaznika")]
        [Required(ErrorMessage = "Broj polaznika je obavezan")]
        public int MaximalniBrojPolaznika { get; set; }

        public int? SeminarID { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2-100 znakova")]
        public string Naziv { get; set; }

    }
}