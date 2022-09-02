using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swift.BBS.Common.Helper;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;
using Swift.BBS.Model.Viewmodels;

namespace Swift.BBS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        
        private readonly IUserInfoService userInfoService;
        private readonly IMapper mapper;

        public UserController(IUserInfoService _userInfoService,IMapper _mapper)
        {
            this.userInfoService = _userInfoService;
            this.mapper = _mapper;
        }
        
        
        [HttpGet("{id}",Name = "GetUser")]
        public async Task<List<UserInfo>> GetUser(int id)
        {
            return await userInfoService.GetListAsync(d => d.Id == id);
        }
        
        
        
        
        
        /// <summary>
        /// 用户个人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<UserInfoDetailsDto>> GetAsync()
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            //从token获取用户id
            var userInfo = await userInfoService.GetAsync(x => x.Id == token.Uid);

            return new MessageModel<UserInfoDetailsDto>()
            {
                success = true,
                msg = "获取成功",
                response = mapper.Map<UserInfoDetailsDto>(userInfo)
            };
        }
        
        
        
        [HttpGet(Name = "KY")]
        public  string Kyname()
        {
            return  "123454";
        }
    }
}