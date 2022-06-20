using DAW.Models;
using DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DAWContext _context;
        private IComponenteRepository _componente;
        private IConfiguratieRepository _configuratie;
        private IPCRepository _pc;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;

        public RepositoryWrapper(DAWContext context)
        {
            _context = context;
        }

        public IComponenteRepository Componente
        {
            get
            {
                if (_componente == null) _componente = new ComponenteRepository(_context);
                return _componente;
            }
        }

        public IConfiguratieRepository Configuratie
        {
            get
            {
                if (_configuratie == null) _configuratie = new ConfiguratieRepository(_context);
                return _configuratie;
            }
        }

        public IPCRepository PC
        {
            get
            {
                if (_pc == null) _pc = new PCRepository(_context);
                return _pc;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
