using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPicture
    {
        Task<IEnumerable<Picture>> GetAllPictureAsync();
        ValueTask<Picture> GetAllPictureByIdAsync(int id);
        Task<Picture> RemovePictureAsync(Picture delPicture);
        Task<Picture> GetPictureByName(string Name);
        Task<Picture> CreatePictureAsync(Picture picture);
        Task UpdatePictureAsync(Picture currentPicture, Picture newPicture);
    }
}
