using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTOs
{
    public class PCUserDTO
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public int Pret { get; set; }
        public List<User> Client { get; set; }
        public PCUserDTO(PC pc)
        {
            this.Id = pc.Id;
            this.Tip = pc.Tip;
            this.Pret = pc.Pret;
            if (pc.Client == null)
                this.Client = new List<User>();
            else
                this.Client = new List<User>(pc.Client);
        }
    }
}
