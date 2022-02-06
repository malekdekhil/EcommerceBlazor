using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOpignion
    {
        Task<IEnumerable<Opinion>> GetAllOpinionyAsync();
        ValueTask<Opinion> GetOpinionByIdAsync(int id);
        Task<Opinion> RemoveOpinionAsync(Opinion delOpinion);
        Task<Opinion> CreateOpinionyAsync(Opinion Opinion);
        Task UpdateOpinionyAsync(Opinion currentOpinion, Opinion newOpinion);
        Task<IEnumerable<Opinion>> GetOpinionsByProductAsync(int idProduct);
    }
}
