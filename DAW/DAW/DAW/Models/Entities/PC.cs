using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class PC
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public int Pret { get; set; }
        public int Id_Client { get; set; }
        public virtual ICollection<User> Client { get; set; }
        public virtual ICollection<Are> Are { get; set; }
    }

}