using DAW.Models;
using DAW.Models.Entities;
using DAW.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class ComponenteRepository : GenericRepository<Componente>, IComponenteRepository
    {
        public ComponenteRepository(DAWContext context) : base(context) { }

        public async Task<List<Componente>> GetAllComponente()
        {
            return await _context.Componente.ToListAsync();
        }

        public async Task<List<Componente>> GetComponenteByName(string nume)
        {
            return await _context.Componente
                .Where(c => c.Nume.ToUpper().Equals(nume.ToUpper())).ToListAsync();
        }
        public async Task<List<Componente>> GetComponenteByPrice(int pret)
        {
            return await _context.Componente
                .Where(c => c.Pret.Equals(pret)).ToListAsync();
        }
        public async Task<List<Componente>> GetComponenteByDetalii(string detalii)
        {
            return await _context.Componente
                .Where(c => c.Detalii.ToUpper().Equals(detalii.ToUpper())).ToListAsync();
        }
    }
}
