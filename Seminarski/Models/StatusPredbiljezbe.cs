using System.ComponentModel.DataAnnotations;

namespace Seminarski.Models
{
    public enum StatusPredbiljezbe
    {
        [Display(Name = "Nepoznato")] Nepoznato = 0,
        [Display(Name = "Neprihvaćena")] Neprihvacena = 1,
        [Display(Name = "Prihvaćena")] Prihvacena = 2
    }
}