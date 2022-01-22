using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
   public interface IUserTmp
    {
        Task AddUserTmp(UserTmp User);
    }
}
