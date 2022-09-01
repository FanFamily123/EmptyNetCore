using AutoMapper;
using Swift.BBS.Model.Models;
using Swift.BBS.Model.Viewmodels;

namespace Swift.BBS.Extension
{
    public class ArticlePorfile: Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public ArticlePorfile()
        {
            CreateMap<CreateArticleInputDto, Article>();

            CreateMap<Article, ArticleDto>();
         


          
        } 
    }
}