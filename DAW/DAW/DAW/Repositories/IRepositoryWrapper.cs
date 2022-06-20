using DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IRepositoryWrapper
    {
        IComponenteRepository Componente { get; }
        IConfiguratieRepository Configuratie { get; }
        IPCRepository PC { get;  }
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }

        Task SaveAsync();
    }
}
