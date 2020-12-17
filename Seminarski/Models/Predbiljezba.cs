using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Seminarski.Models
{
    [Table("Predbiljezbe")]
    public class Predbiljezba
    {
        [Key]
        public int PredbiljezbaID { get; set; }

        [Required(ErrorMessage = "Mobitel je obavezan")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "8 - 30 znakova")]
        public string Mobitel { get; set; }

        [Required(ErrorMessage = "Email je obavezan")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "5 - 500 znakova")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adresa je obavezna")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Minimum 8 znakova")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 - 50 znakova")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 - 50 znakova")]
        public string Ime { get; set; }


        private DateTime? _datum;
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy. HH:mm}")]
        public DateTime? Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        public StatusPredbiljezbe Status { get; set; } = 0;

        [ForeignKey("Seminar")]
        public int SeminarID { get; set; }
        public Seminar Seminar { get; set; }

        public Predbiljezba()
        {
            if(_datum == null)
            {
                Datum = DateTime.Now;
            }
            Datum = _datum;
        }

    }
}