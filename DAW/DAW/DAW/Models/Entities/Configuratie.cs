using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class Configuratie
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Procesor { get; set; }
        public int RAM { get; set; }
        public int Stocare { get; set; }
        public virtual ICollection<Are> Are { get; set; }
    }
}
