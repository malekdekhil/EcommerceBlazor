using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProvider
    {
        Task<IEnumerable<Provider>> GetAllProviderAsync();
        ValueTask<Provider> GetAllProviderByIdAsync(int id);
        Task<Provider> RemoveProviderAsync(Provider delProvider);
        Task<Provider> CreateProviderAsync(Provider provider);
        Task UpdateProvideryAsync(Provider currentProvider, Provider newProvider);
    }
}
