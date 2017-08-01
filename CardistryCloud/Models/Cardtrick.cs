using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardistryCloud.Models
{
    public class Cardtrick
    {

        public int ID { get; set; }
        public string Titel { get; set; }
        public int Kategorie { get; set; }
        public int Schwierigkeitsgrad { get; set; }
        public string Beschreibung { get; set; }

    }
}
