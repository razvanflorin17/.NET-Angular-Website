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
    public class ConfiguratieRepository : GenericRepository<Configuratie>, IConfiguratieRepository
    {
        public ConfiguratieRepository(DAWContext context) : base(context) { }

        public async Task<List<Configuratie>> GetAllConfiguratie()
        {
            return await _context.Configuratie.ToListAsync();
        }

        public async Task<List<Configuratie>> GetConfiguratieByPlaca(string placa)
        {
            return await _context.Configuratie
                .Where(p => p.Placa.ToUpper().Equals(placa.ToUpper())).ToListAsync();
        }
        public async Task<List<Configuratie>> GetConfiguratieByProcesor(string procesor)
        {
            return await _context.Configuratie
                .Where(p => p.Procesor.ToUpper().Equals(procesor.ToUpper())).ToListAsync();
        }
        public async Task<List<Configuratie>> GetConfiguratieByRam(int ram)
        {
            return await _context.Configuratie
                .Where(p => p.RAM.Equals(ram)).ToListAsync();
        }
        public async Task<List<Configuratie>> GetConfiguratieByStocare(int stocare)
        {
            return await _context.Configuratie
                .Where(p => p.Stocare.Equals(stocare)).ToListAsync();
        }

        public async Task<List<PC>> GetPCsByConfiguratie(int id)
        {
            return await _context.Configuratie.Join(_context.Are, c => id, a => a.Id_Configuratie, (c, a) => a).Join(_context.PC, a => a.Id_PC, p => p.Id, (a, p) => p).ToListAsync();
        }
    }
}
