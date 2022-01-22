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
    public class ClsUserTmp:IUserTmp
    {
        private IUnitOfWork unitOfWork;

        public ClsUserTmp(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task AddUserTmp(UserTmp User)
        {
            await unitOfWork.UserTmp.AddAsync(User);
            await unitOfWork.CommitAsync();
        }
    }
}
