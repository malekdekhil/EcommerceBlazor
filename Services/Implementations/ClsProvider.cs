using Domains;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkManager;

namespace Services.Implementations
{
    public class ClsProvider : IProvider
    {
        private readonly IUnitOfWork unitOfWork;

        public ClsProvider(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Provider> CreateProviderAsync(Provider provider)
        {
            await unitOfWork.Providers.AddAsync(provider);
            await unitOfWork.CommitAsync();
            return provider;
        }

        public async Task<IEnumerable<Provider>> GetAllProviderAsync()
        {
            return await unitOfWork.Providers.GetAllAsync();
        }

        public async ValueTask<Provider> GetAllProviderByIdAsync(int id)
        {
            return await unitOfWork.Providers.GetByIdAsync(id);
        }

        public async Task<Provider> RemoveProviderAsync(Provider delProvider)
        {
            unitOfWork.Providers.Remove(delProvider);
            await unitOfWork.CommitAsync();
            return delProvider;
        }

        public async Task UpdateProvideryAsync(Provider currentProvider, Provider newProvider)
        {
            currentProvider.Adress = newProvider.Adress;
            currentProvider.City = newProvider.City;
            currentProvider.CodeZip = newProvider.CodeZip;
            currentProvider.Country = newProvider.Country;
            currentProvider.DateOdPurchase = newProvider.DateOdPurchase;
            currentProvider.Email = newProvider.Email;
            currentProvider.Invoices = newProvider.Invoices;
            currentProvider.PhoneNumber = newProvider.PhoneNumber;
            currentProvider.name = newProvider.name;
            currentProvider.Info = newProvider.Info;
             await unitOfWork.CommitAsync();
        }
    }
}
