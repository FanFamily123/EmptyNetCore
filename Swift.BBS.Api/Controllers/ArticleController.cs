using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swift.BBS.Common.Helper;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;
using Swift.BBS.Model.Viewmodels;
using Swift.BBS.Services;

namespace Swift.BBS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController:ControllerBase
    {
        private readonly IArticleService articleService;
        private readonly IMapper mapper;
        private readonly IUserInfoService userInfoService;

        public ArticleController(IArticleService _ariticleService,IMapper _mapper,IUserInfoService _userInfoService)
        {
            this.articleService = _ariticleService;
            this.mapper = _mapper;
            this.userInfoService = _userInfoService;
        }

        [HttpGet]
        public void AddArticle()
        {
           
        }
        
        // [HttpGet("{id}",Name = "Get")]
        // public List<Article> Get(int id)
        // {
        //     return articleService.Query(d => d.Id == id);
        // }
        
        /// <summary>
        /// 创建文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> CreateAsync(CreateArticleInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);

            var entity = mapper.Map<Article>(input);
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = token.Uid;
            await articleService.InsertAsync(entity, true);

            return new MessageModel<string>()
            {
                success = true,
                msg = "创建成功"
            };
        }


        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<ArticleDto>>> GetList(int page, int pageSize)
        {
            // 这里只是展示用法，还可以通过懒加载的形式 或 自定义仓储去Include UserInfo
            var entityList = await articleService.GetPagedListAsync(page, pageSize, nameof(Article.CreateTime));
            var articleUserIdList = entityList.Select(x => x.CreateUserId);
            var userList = await userInfoService.GetListAsync(x=> articleUserIdList.Contains(x.Id));
            var response = mapper.Map<List<ArticleDto>>(entityList);
            foreach (var item in response)
            {
                var user = userList.FirstOrDefault(x => x.Id == item.CreateUserId);
                item.UserName = user.UserName;
                item.HeadPortrait = user.HeadPortrait;
            }
            return new MessageModel<List<ArticleDto>>()
            {
                success = true,
                msg = "获取成功",
                response = response
            };
        }
        
  

        [HttpGet]
        public async Task<MessageModel<ArticleDetailsDto>> Get(int id)
        {
            // 通过自定义服务层处理内部业务
            var entity = await articleService.GetAsync(d => d.Id == id);
            var result = mapper.Map<ArticleDetailsDto>(entity);
            return new MessageModel<ArticleDetailsDto>()
            {
                success = true,
                msg = "获取成功",
                response = result
            };
        }
        
    }
}