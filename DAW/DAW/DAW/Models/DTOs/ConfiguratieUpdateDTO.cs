using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTOs
{
    public class ConfiguratieUpdateDTO
    {
        public string Placa { get; set; }
        public string Procesor { get; set; }
        public int RAM { get; set; }
        public int Stocare { get; set; }
    }
}
