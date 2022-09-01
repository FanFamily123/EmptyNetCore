using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;

namespace Swift.BBS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        
        private readonly IUserInfoService userInfoService;
        
        public UserController(IUserInfoService _userInfoService)
        {
            this.userInfoService = _userInfoService;
        }
        
        
        [HttpGet("{id}",Name = "GetUser")]
        public async Task<List<UserInfo>> GetUser(int id)
        {
            return await userInfoService.GetListAsync(d => d.Id == id);
        }
    }
}