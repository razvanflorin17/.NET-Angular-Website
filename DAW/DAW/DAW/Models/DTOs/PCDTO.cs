using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTOs
{
    public class PCDTO
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public int Pret { get; set; }
        public PCDTO(PC pc)
        {
            this.Id = pc.Id;
            this.Tip = pc.Tip;
            this.Pret = pc.Pret;
        }
    }
}
