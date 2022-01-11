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
    public class ClsOpinion : IOpignion
    {
        private readonly IUnitOfWork unitOfWork;

        public ClsOpinion(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Opinion> CreateOpinionyAsync(Opinion Opinion)
        {
            await unitOfWork.Opinions.AddAsync(Opinion);
            await unitOfWork.CommitAsync();
            return Opinion;
        }

        public async ValueTask<Opinion> GetAllOpinionByIdAsync(int id)
        {
             return await unitOfWork.Opinions.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Opinion>> GetAllOpinionyAsync()
        {
            return await unitOfWork.Opinions.GetAllAsync();
        }

        public async Task<Opinion> RemoveOpinionAsync(Opinion delOpinion)
        {
            unitOfWork.Opinions.Remove(delOpinion);
            await unitOfWork.CommitAsync();
            return delOpinion;
        }

        public async Task UpdateOpinionyAsync(Opinion currentCategory, Opinion newCategory)
        {
            currentCategory.Commentaire = newCategory.Commentaire;
            await unitOfWork.CommitAsync();

        }
    }
}
