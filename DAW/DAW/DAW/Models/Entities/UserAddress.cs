using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string Tara { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }
        public int Cod_Postal { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
