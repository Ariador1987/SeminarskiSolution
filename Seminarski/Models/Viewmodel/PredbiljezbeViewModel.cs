using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminarski.Models.Viewmodel
{
    public class PredbiljezbeViewModel
    {
        public Predbiljezba Predbiljezba { get; set; }
        public List<Seminar> Seminar { get; set; }
    }
}