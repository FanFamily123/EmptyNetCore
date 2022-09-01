using Swift.BBS.IRepositories;
using Swift.BBS.Model.Models;
using Swift.BBS.Repositories.Base;
using Swift.BBS.Repositories.EfContext;

namespace Swift.BBS.Repositories
{
    public class UserInfoRepository:BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(SwiftCodeBbsContext context) : base(context)
        {
        }
    }
}