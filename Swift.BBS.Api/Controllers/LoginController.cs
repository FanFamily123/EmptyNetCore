using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swift.BBS.Common.Helper;

namespace Swift.BBS.Api.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        [HttpGet]
        public async Task<Object> GetJwtStr(string name,string pass)
        {
            TokenModelJwt tokenModelJwt = new TokenModelJwt {Uid = 1, Role = "admin"};
            var jwtstr = JwtHelper.IssueJwt(tokenModelJwt);
            var suc = true;
            return Ok(new
            {
                success = suc,
                token = jwtstr
            });
        }
        
        
        
        
        
        
    }
}