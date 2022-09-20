using Swift.BBS.IRepositories.Base;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;
using Swift.BBS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.BBS.Services
{
    public class ImageService : BaseServices<Images>, IImageService
    {
        public ImageService(IBaseRepository<Images> baseDal) : base(baseDal)
        {
        }
    }
}
