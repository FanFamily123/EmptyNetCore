using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;
using Swift.BBS.Services;

namespace Swift.BBS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController:ControllerBase
    {
        private readonly IArticleService articleService;
        public ArticleController(IArticleService _ariticleService)
        {
            this.articleService = _ariticleService;
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
        
        
        [HttpGet("{id}",Name = "Get")]
        public async Task<List<Article>> Get(int id)
        {
            return await articleService.GetListAsync(d => d.Id == id);
        }
        
    }
}