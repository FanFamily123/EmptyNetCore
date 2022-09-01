using Swift.BBS.IRepositories.Base;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;
using Swift.BBS.Services.Base;

namespace Swift.BBS.Services
{
    public class UserInfoService:BaseServices<UserInfo>,IUserInfoService
    {
        public UserInfoService(IBaseRepository<UserInfo> baseDal) : base(baseDal)
        {
        }
    }
}