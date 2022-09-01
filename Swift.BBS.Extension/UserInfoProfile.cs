using AutoMapper;
using Swift.BBS.Model.Models;
using Swift.BBS.Model.Viewmodels;

namespace Swift.BBS.Extension
{
    public class UserInfoProfile: Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public UserInfoProfile()
        {
         

            CreateMap<UserInfo, UserInfoDto>();
         


          
        } 
    }
}