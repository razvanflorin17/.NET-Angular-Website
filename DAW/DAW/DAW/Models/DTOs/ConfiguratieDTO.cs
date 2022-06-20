using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTOs
{
    public class ConfiguratieDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Procesor { get; set; }
        public int RAM { get; set; }
        public int Stocare { get; set; }

        public ConfiguratieDTO(Configuratie configuratie)
        {
            this.Id = configuratie.Id;
            this.Placa = configuratie.Placa;
            this.Procesor = configuratie.Procesor;
            this.RAM = configuratie.RAM;
            this.Stocare = configuratie.Stocare;
        }
    }
}
