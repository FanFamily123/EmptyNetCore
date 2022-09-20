using Swift.BBS.IRepositories;
using Swift.BBS.Model.Models;
using Swift.BBS.Repositories.Base;
using Swift.BBS.Repositories.EfContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.BBS.Repositories
{
    public class ImagesRepository : BaseRepository<Images>, IImagesRepository
    {
        public ImagesRepository(SwiftCodeBbsContext context) : base(context)
        {
        }
    }
}
