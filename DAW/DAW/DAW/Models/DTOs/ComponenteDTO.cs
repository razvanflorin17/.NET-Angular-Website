using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTOs
{
    public class ComponenteDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int Pret { get; set; }
        public string Detalii { get; set; }

        public ComponenteDTO(Componente componente)
        {
            this.Id = componente.Id;
            this.Nume = componente.Nume;
            this.Pret = componente.Pret;
            this.Detalii = componente.Detalii;
        }
    }
}
