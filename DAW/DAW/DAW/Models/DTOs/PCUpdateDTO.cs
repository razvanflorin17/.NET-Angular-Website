using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTOs
{
    public class PCUpdateDTO
    {
        public string Tip { get; set; }
        public int Pret { get; set; }
        public int Id_Client { get; set; }
    }
}
