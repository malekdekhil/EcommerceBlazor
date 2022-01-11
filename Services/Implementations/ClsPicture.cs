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
    public class ClsPicture : IPicture
    {
        private readonly IUnitOfWork unitOfWork;

        public ClsPicture(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Picture> CreatePictureAsync(Picture picture)
        {
            await unitOfWork.Pictures.AddAsync(picture);
            await unitOfWork.CommitAsync();
            return picture;
        }

        public async Task<IEnumerable<Picture>> GetAllPictureAsync()
        {
           return await unitOfWork.Pictures.GetAllAsync();
        }

        public async ValueTask<Picture> GetAllPictureByIdAsync(int id)
        {
            return await unitOfWork.Pictures.GetByIdAsync(id);
        }

        public async Task<Picture> GetPictureByName(string Name)
        {
            return await unitOfWork.Pictures.GetByName(Name);
        }

        public async Task<Picture> RemovePictureAsync(Picture delPicture)
        {
            unitOfWork.Pictures.Remove(delPicture);
            await unitOfWork.CommitAsync();
            return delPicture;
        }

        public async Task UpdatePictureAsync(Picture currentPicture, Picture newPicture)
        {
            currentPicture.Name = newPicture.Name;
            currentPicture.UrlPicture = newPicture.UrlPicture;
            currentPicture.IdProduct_Fk = newPicture.IdProduct_Fk;
             await unitOfWork.CommitAsync();
        }
    }
}
