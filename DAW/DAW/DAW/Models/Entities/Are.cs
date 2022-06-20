using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class Are
    {
        public int Id_PC { get; set; }
        public int Id_Configuratie { get; set; }
        public virtual PC PC { get; set; }
        public virtual Configuratie Configuratie { get; set; }
    }
}
