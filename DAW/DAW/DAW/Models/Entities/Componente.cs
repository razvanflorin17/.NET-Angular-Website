using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class Componente
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int Pret { get; set; }
        public string Detalii { get; set; }
        public int UserId { get; set; }
        public virtual User Client { get; set; }
    }
}
